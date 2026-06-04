using System.Windows;

namespace WpfApp9.Services
{
    public class WPFDialogService : IDialogService
    {
        public bool GetConfirmation(string message = "Do you want to proceed?", string title = "Confirmation required")
        {
            MessageBoxResult result = MessageBox.Show(message, title, MessageBoxButton.YesNo);

            return result == MessageBoxResult.Yes;
        }

        public void ShowError(string message = "There was an error while executing the program", string title = "An error occured")
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void ShowInfo(string message, string title = "Информация")
        {
            MessageBox.Show(message, title);
        }
       
        
    }
}
