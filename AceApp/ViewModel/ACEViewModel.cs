using AceApp.Model;
using AceApp.ViewModel.Commands;
using AceApp.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceApp.ViewModel
{
    public class ACEViewModel : INotifyPropertyChanged
    {
        public ACEViewModel()
        {
            NewMachineCommand = new NewMachineCommand(this);
            NewTaskBoxCommand = new NewTaskBoxCommand(this);
            CloseCommand = new CloseCommand(this);
            Machines = new ObservableCollection<Machine>();
            Tasks = new ObservableCollection<MachineTask>();
            TaskBoxs = new ObservableCollection<MachineTaskBox>();
            GetMachines();
        }

        //==========================================================================
        //OBSERVABLE_COLLECTION
        public ObservableCollection<Machine> Machines { get; set; }

        public ObservableCollection<MachineTaskBox> TaskBoxs { get; set; }
        public ObservableCollection<MachineTask> Tasks { get; set; }

        //==========================================================================
        //PROPERTIES
        private Machine _selectedMachine;

        public Machine SelectedMachine
        {
            get { return _selectedMachine; }
            set
            {
                _selectedMachine = value;
                //we need to get tasks from machine that is selected
                GetTaskBox();
                OnPropertyChanged(nameof(SelectedMachine));

                //TODO: get machine tasks
            }
        }

        //---------------------------------------------------------------------------
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //---------------------------------------------------------------------------

        //===========================================================================
        //COMMANDS
        public NewMachineCommand NewMachineCommand { get; set; }

        public NewTaskBoxCommand NewTaskBoxCommand { get; set; }
        public CloseCommand CloseCommand { get; set; }

        //===========================================================================
        //METHODS
        //Create New Machine  Method
        public void CreateMachine()
        {
            Machine newMachine = new Machine()
            {
                MachineName = "New Machine",
            };
            DataBaseHelper.Insert(newMachine);

            GetMachines();
        }

        //---------------------------------------------------------------------------
        // Create Task for specific machine
        public void CreateTaskBox(int machineID)
        {
            MachineTaskBox taskBox = new MachineTaskBox()
            {
                MachineId = machineID,
                BoxTitle = "New Task Box"
            };

            DataBaseHelper.Insert(taskBox.BoxTitle.ToString());
            GetTaskBox();
        }

        //---------------------------------------------------------------------------
        //Get Machines
        private void GetMachines()
        {
            var machines = DataBaseHelper.Read<Machine>();
            Machines.Clear();
            foreach (var machine in machines)
            {
                Machines.Add(machine);
            }
        }

        //---------------------------------------------------------------------------
        //Get TaskBoxs
        private void GetTaskBox()
        {
            if (SelectedMachine != null)
            {
                var taskboxes = DataBaseHelper.Read<MachineTaskBox>().Where(n => n.MachineId == SelectedMachine.Id).ToList();
                TaskBoxs.Clear();
                foreach (var box in taskboxes)
                {
                    TaskBoxs.Add(box);
                }
            }
        }
    }
}