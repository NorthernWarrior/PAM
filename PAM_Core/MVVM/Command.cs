using System;
using System.Windows.Input;

namespace PAM.MVVM
{
    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        Action execute;
        Func<bool> canExecute;

        public Command(Action execute)
        {
            this.execute = execute;
        }
        public Command(Action execute, Func<bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public virtual bool CanExecute(object parameter)
        {
            if (canExecute == null)
                return true;
            else
                return canExecute();
        }

        public virtual void Execute(object parameter)
        {
            if (execute != null)
                execute();
        }
    }
}
