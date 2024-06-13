using AceApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AceApp.ViewModel.Commands
{
    public class NewMachineCommand : ICommand
    {
        //Create new ACEViewModel class as property to use it for command
        public ACEViewModel AceVM { get; set; }

        //====================================================================================
        //ctor for implement command and bind with AceViewModel
        public NewMachineCommand(ACEViewModel vm)
        {
            AceVM = vm;
        }

        //====================================================================================
        //ICommand implementation
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            AceVM.CreateMachine();
        }
    }
}