using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TemplateTest.Enums;

namespace TemplateTest.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {

        private ObservableCollection<ControlsViewModel> controls;
        public ObservableCollection<ControlsViewModel> Controls {
            get {
                return  controls;
            } set {
                if(controls == value) 
                    return;

                controls = value;
                OnPropertyChanged("Controls");
            }
        }

        public MainPageViewModel()
        {
            LoadData();
        }

        private  void LoadData()
        {
            Controls = new ObservableCollection<ControlsViewModel>()
            {
                new ControlsViewModel
                {
                    Label = "Start Date",
                    ControlType = CustomControl.DateField
                },
                new ControlsViewModel
                {
                    Label = "Start Time",
                    ControlType = CustomControl.TimeField
                },
                new ControlsViewModel
                {
                    Label = "End Time",
                    ControlType = CustomControl.TimeField
                },
                new ControlsViewModel
                {
                    Label = "Text Entry One",
                    ControlType = CustomControl.EntryField
                },
                new ControlsViewModel
                {
                    Label = "Text Entry Two",
                    ControlType = CustomControl.EntryField
                },
                new ControlsViewModel
                {
                    Label = "Text Entry Three",
                    ControlType = CustomControl.EntryField
                },
                new ControlsViewModel
                {
                    Label = "Text Entry Three",
                    ControlType = CustomControl.EntryField
                },
                new ControlsViewModel
                {
                    Label = "Text Entry Three",
                    ControlType = CustomControl.EntryField
                },
                new ControlsViewModel
                {
                    Label = "Text Entry Three",
                    ControlType = CustomControl.EntryField
                },
                new ControlsViewModel
                {
                    Label = "Text Entry Three",
                    ControlType = CustomControl.EntryField
                },
                new ControlsViewModel
                {
                    Label = "Text Entry Three",
                    ControlType = CustomControl.EntryField
                },
                new ControlsViewModel
                {
                    Label = "Text Entry Three",
                    ControlType = CustomControl.EntryField
                },
                new ControlsViewModel
                {
                    Label = "Text Entry Three",
                    ControlType = CustomControl.EntryField
                },
                new ControlsViewModel
                {
                    Label = "Text Entry Three",
                    ControlType = CustomControl.EntryField
                }
            };
        }
    }
}
