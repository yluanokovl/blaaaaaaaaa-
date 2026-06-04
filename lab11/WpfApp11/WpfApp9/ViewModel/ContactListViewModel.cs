using WpfApp9.Interface;
using WpfApp9.Model.App;
using WpfApp9.Model.Data;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WpfApp9.ViewModel
{
    public class ContactListViewModel: ViewModelBase
    {
        public ObservableCollection<Contact> Contacts { get; }
        
        private string _name = string.Empty;
        private string _phone = string.Empty;
        private string _errMsg = string.Empty;
        private Contact? _selectedContact;
        private IDialogService _dialogService;
        private int id = 0;

        public string ErrorMsg 
        { 
            get => _errMsg;
            set => Set(ref _errMsg, value);
        }
        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
        public string Phone
        {
            get => _phone;
            set => Set(ref _phone, value);
        }
        public Contact? SelectedContact
        {
            get => _selectedContact;
            set => Set(ref _selectedContact, value);
        }



        // Команды
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand EditCommand { get; }
        public ContactListViewModel(IDialogService ds, INavigationService navigation) : base(navigation)
        {
            _dialogService = ds;
            Contacts = new ObservableCollection<Contact>();
            AddCommand = new RelayCommand(
            AddContact, () => CanAddContact());

            DeleteCommand = new RelayCommand(
            DeleteContact, () => CanDeleteOrEditContact());

            EditCommand = new RelayCommand(
            () => _navigation.NavigateTo<ContactEditViewModel>(SelectedContact),
            () => CanDeleteOrEditContact());
        }
        private void AddContact()
        {
            
            Contact c = new Contact(id++, _name, _phone);
            if (c.Validate())
            {
                if (Contacts.Any(c => c.Phone == _phone))
                {
                    _dialogService.ShowError("A contact with that phone already exists");
                    ErrorMsg = $"A contact with the number {_phone} already exists";
                }
                else
                {
                    Contacts.Add(c);
                    Name = string.Empty;
                    Phone = string.Empty;
                    ErrorMsg = string.Empty;
                }
            }
            else
            {
                ErrorMsg = $"Invalid info";
            }
        }
        private bool CanAddContact()
        {
            return (!string.IsNullOrEmpty(_name) && !string.IsNullOrEmpty(_phone));
        }
        private void DeleteContact()
        {
            if (SelectedContact is not null && Contacts.Contains(SelectedContact))
            {
                if (_dialogService.GetConfirmation($"Delete contact {SelectedContact}?"))
                {
                    Contacts.Remove(SelectedContact);
                }
            }
        }
        private bool CanDeleteOrEditContact()
        {
            return (SelectedContact is not null); 
        }
    }
}
