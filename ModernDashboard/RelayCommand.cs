using System;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Input;

namespace ModernDashboard
{
    //Summary
    //RelayCommand allows you to inject the ccommand's logic via delegates passed into its constructor.
    //this method enables ViewModel classes to impplement command
    //Summary
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;
        public RelayCommand(Action<object> execute)
        {
            this.execute = execute;
            canExecute = null;
        }

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        // <Summary>
        // canExecuteChanged delegates the event subscription to the CommandManager. RequerySuggested event.
        // This ensures that the WPF commanding infrastructure asks all RelayCommand objects if they can execute whenever 
        // It asks the built-in commands
        // <Summary>  
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || CanExecute(parameter);
        }
        public void Execute(object parameter)
        {
            execute(parameter)
        }


        //public event EventHandler? CanExecuteChanged;

        //public bool CanExecute(object? parameter)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Execute(object? parameter)
        //{
        //    throw new NotImplementedException();
        //}
    }

}
