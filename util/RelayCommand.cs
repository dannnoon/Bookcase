using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bookcase.util
{
    public class RelayCommand : ICommand
    {
        public delegate void ExecuteHandler(Object parameter);

        private readonly Func<Boolean> _canExecute;
        private event ExecuteHandler _execute;
        
        public RelayCommand(ExecuteHandler execute)
          : this(execute, null)
        {
        }

        public RelayCommand(ExecuteHandler execute, Func<Boolean> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException("execute");
            _execute += execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_canExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        public Boolean CanExecute(Object parameter)
        {
            return _canExecute == null ? true : _canExecute();
        }

        public void Execute(Object parameter)
        {
            _execute?.Invoke(parameter);
        }
    }
}
