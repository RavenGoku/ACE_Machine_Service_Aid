using AceApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AceApp.ViewModel.Commands
{
    public class NewTaskCommand : ICommand
    {
        private ACEViewModel ACEView { get; set; }

        public NewTaskCommand(ACEViewModel aceVM)
        {
            ACEView = aceVM;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            MachineTaskBox selectedMachineTaskBox = parameter as MachineTaskBox;
            if (selectedMachineTaskBox != null)
            {
                return true;
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            MachineTaskBox selectedMachineTaskBox = parameter as MachineTaskBox;
            ACEView.CreateTask(selectedMachineTaskBox.Id);
        }
    }
}