using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateTest.ViewModel;
using Xamarin.Forms;

namespace TemplateTest
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel vm;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm = new MainPageViewModel();
            BindingContext = vm;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            vm = null;
            BindingContext = null;
        }
    }
}
