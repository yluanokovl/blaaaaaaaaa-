using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp9.Services
{
    public interface IDialogService
    {
        public void ShowInfo(string message, string title = "Информация");
        public void ShowError(string message = "There was an error while executing the program", string title = "An error occured");
        public bool GetConfirmation(string message = "Do you want to proceed?", string title = "Confirmation required");
    }
}
