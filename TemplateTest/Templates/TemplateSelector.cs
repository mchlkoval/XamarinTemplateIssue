using System;
using System.Collections.Generic;
using System.Text;
using TemplateTest.Enums;
using TemplateTest.ViewModel;
using Xamarin.Forms;

namespace TemplateTest.Templates
{
    public class TemplateSelector : DataTemplateSelector
    {

        public DataTemplate TimeTemplateSelector { get; set; }
        public DataTemplate DateTemplateSelector { get; set; }
        public DataTemplate EntryTemplateSelector { get; set; }
        public DataTemplate EmptyTemplateSelector { get; set; }

        public TemplateSelector()
        {
            TimeTemplateSelector = new DataTemplate(typeof(TimeTemplate));
            DateTemplateSelector = new DataTemplate(typeof(DateTemplate));
            EntryTemplateSelector = new DataTemplate(typeof(EntryTemplate));
            EmptyTemplateSelector = new DataTemplate(typeof(EmptyCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var vm = item as ControlsViewModel;
            
            return PickTemplateByType(vm);
        }

        private DataTemplate PickTemplateByType(ControlsViewModel model)
        {
            try
            {
                if(model == null)
                {
                    return EmptyTemplateSelector;
                }

                switch(model.ControlType)
                {
                    case CustomControl.DateField: 
                        return DateTemplateSelector;
                    case CustomControl.TimeField:
                        return TimeTemplateSelector;
                    case CustomControl.EntryField:
                        return EntryTemplateSelector;
                    default:
                        return EmptyTemplateSelector;
                }

            } catch (Exception e)
            {
                return EmptyTemplateSelector;
            }
        }
    }
}
