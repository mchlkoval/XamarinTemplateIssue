using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateTest.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TemplateTest.Templates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateTemplate : ViewCell
    {
        private ControlsViewModel controlViewModel;

        public DateTemplate()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            controlViewModel = this.BindingContext as ControlsViewModel;
            if(controlViewModel != null)
            {
                SNDate.DateSelected += SNDate_DateSelected;
                SNDate.Focused += SNDate_Focused;
            }
            
        }

        private void SNDate_Focused(object sender, FocusEventArgs e)
         {
            if(controlViewModel.DateFocusedCommand.CanExecute(null))
            {
                controlViewModel.DateFocusedCommand.Execute(null);
            }
         }

        private void SNDate_DateSelected(object sender, DateChangedEventArgs e) {

            if(e.NewDate == null)  {
                return;
            }
            
            if(controlViewModel.DateSelectedCommand.CanExecute(null))
            {
                controlViewModel.DateSelectedCommand.Execute(e.NewDate.ToShortDateString());
            }
        }
    }
}