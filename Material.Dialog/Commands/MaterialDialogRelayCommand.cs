using System;
using System.Windows.Input;
using Avalonia.Threading;

namespace Material.Dialog.Commands
{
    /// <summary>
    /// Do not use it in your project! It should be used only inside of Material.Dialog.<br/>
    /// If you want to use this one, you should copy all whole code and paste them to your new RelayCommand.cs source file.
    /// </summary>
    public class MaterialDialogRelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool>? _canExecute;

        public event EventHandler? CanExecuteChanged;

        public MaterialDialogRelayCommand(Action<object> execute, Func<object, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            var result = _canExecute == null || _canExecute(parameter);
            return result;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        // Call this method to tell AvaloniaUI about this command can be executed at this moment.
        public void RaiseCanExecute()
        {
            var handler = CanExecuteChanged;

            if (handler != null)
            {
                // Call CanExecute via Dispatcher.UIThread.Post to prevent CanExecute can't be called from other thread.
                Dispatcher.UIThread.Post(delegate { handler(this, EventArgs.Empty); });
            }
        }
    }
}