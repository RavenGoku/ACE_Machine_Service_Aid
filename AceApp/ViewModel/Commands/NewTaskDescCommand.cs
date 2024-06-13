using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AceApp.ViewModel.Commands
{
    public class NewTaskDescCommand : ICommand
    {
        public ACEViewModel AceVM { get; set; }

        public NewTaskDescCommand(ACEViewModel vm)
        {
            AceVM = vm;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            //TODO : Create New Machine
        }
    }
}