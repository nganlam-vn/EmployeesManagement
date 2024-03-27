using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input; //import the ICommand interface from the System.Windows.Input namespace

namespace test2.Commands
{
    public class RelayCommand : ICommand //implement the ICommand interface
    {
        public event EventHandler? CanExecuteChanged;
        private Action DoWork; //create a private field of type Action
        public RelayCommand(Action work) //create a constructor that takes an Action parameter
        {
            DoWork = work; //initialize the DoWork field
        }
       

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            DoWork();
        }
    }
}
