using AceApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AceApp.ViewModel.Commands
{
    public class NewTaskBoxCommand : ICommand
    {
        public ACEViewModel AceVM { get; set; }

        public NewTaskBoxCommand(ACEViewModel vm)
        {
            AceVM = vm;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            Machine selectedMachine = parameter as Machine;

            if (selectedMachine != null)
            { return true; }

            return false;
        }

        public void Execute(object? parameter)
        {
            Machine selectedMachine = parameter as Machine;
            AceVM.CreateTaskBox(selectedMachine.Id);
        }
    }
}