using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFCurrency.Commands
{
    public class BasicCommandParameter : ICommand
    {
        private Action<object> commandAction;

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public BasicCommandParameter
            (Action<object> action)
        {
            commandAction = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            commandAction(parameter);
        }
    }
}
