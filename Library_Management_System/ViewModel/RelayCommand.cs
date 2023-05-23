using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library_Management_System.ViewModel
{
    public class RelayCommand : ICommand
    {
        // These are two private fields that hold the delegate references to the action that will be executed
        // when the command is executed (_execute), and to the function that determines whether the command
        // can be executed or not (_canExecute).

        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;


        // implementation of the CanExecuteChanged event from the ICommand interface.
        // It allows the UI to be notified when the CanExecute method returns a different value,
        // so that UI elements bound to the command can update their enabled/disabled state accordingly.
        // The event is raised whenever the CommandManager.RequerySuggested event is raised, which happens
        // when the CommandManager.InvalidateRequerySuggested method is called.
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }



        // This is the constructor for the RelayCommand class. It takes two parameters: an execute action
        // and an optional canExecute function. The execute action is required, and specifies what the command
        // should do when it is executed. The canExecute function is optional, and specifies whether the command
        // can be executed or not. If the canExecute function is not provided, the command can always be executed
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute)
        {
            _execute = execute;
        }



        // It determines whether the command can be executed or not, based on the result of the _canExecute function.
        // If the _canExecute function is not provided, the command can always be executed.
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
