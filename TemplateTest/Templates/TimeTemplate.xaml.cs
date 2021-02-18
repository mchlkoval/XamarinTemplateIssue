using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateTest.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TemplateTest.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimeTemplate : ViewCell
    {
        private ControlsViewModel viewModel;

        public TimeTemplate()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            this.viewModel = BindingContext as ControlsViewModel;
            BindingContext = viewModel;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            SNTime.PropertyChanged -= MyTimePicker_PropertyChanged;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            SNTime.PropertyChanged += MyTimePicker_PropertyChanged;
        }

        private void MyTimePicker_PropertyChanged(object sender, PropertyChangedEventArgs e) {


            if (e.PropertyName == TimePicker.TimeProperty.PropertyName && viewModel != null) {
                if(viewModel.TimePickerPropertyChangedCommand.CanExecute(null))
                {
                    viewModel.TimePickerPropertyChangedCommand.Execute(viewModel.SnTime.ToString());
                }

            }
        }
    }
}