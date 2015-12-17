using PAM.Commands;
using PAM.MVVM;
using System.Windows;

namespace PAM.ViewModels
{
    public class MainViewModel : Model
    {
        //****************************************************************************************************************

        public OpenProcessCommand OpenDocumentsCommand { get; private set; }
        public OpenProcessCommand OpenExpensesCommand { get; private set; }
        public Command CloseAppCommand { get; private set; }

        //****************************************************************************************************************

        public MainViewModel()
        {
            OpenDocumentsCommand = new OpenProcessCommand("PAM_Documents.exe");
            OpenExpensesCommand = new OpenProcessCommand("PAM_Expenses.exe");
            CloseAppCommand = new Command(closeApp);
        }

        //****************************************************************************************************************

        private void closeApp()
        {
            OpenDocumentsCommand.CloseProcess();
            OpenExpensesCommand.CloseProcess();

            Application.Current.Shutdown();
        }
    }
}
