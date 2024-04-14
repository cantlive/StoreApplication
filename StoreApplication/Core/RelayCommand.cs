using System.Windows.Input;

namespace StoreApplication.Core
{
    /// <summary>
    /// Represents a command that can be bound to a user interface control, typically used for handling user actions such as button clicks.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        /// <summary>
        /// Initializes a new instance of the RelayCommand class with the specified action to execute and a predicate that determines whether the command can execute.
        /// </summary>
        /// <param name="execute">The action to execute when the command is invoked.</param>
        /// <param name="canExecute">A predicate that determines whether the command can execute. If null, the command is assumed to always be executable.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command. May be null if no data is required.</param>
        /// <returns>True if the command can execute, otherwise false.</returns>
        public bool CanExecute(object parameter) => _canExecute(parameter);

        /// <summary>
        /// Executes the command logic.
        /// </summary>
        /// <param name="parameter">Data used by the command. May be null if no data is required.</param>
        public void Execute(object parameter) => _execute(parameter);

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
