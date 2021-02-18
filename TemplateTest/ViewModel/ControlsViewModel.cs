using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TemplateTest.Enums;
using Xamarin.Forms;

namespace TemplateTest.ViewModel
{
    public class ControlsViewModel : BaseViewModel
    {
        private ICommand  dateSelectedCommand;
        private ICommand  dateFocusedCommand;
        private ICommand timePickerPropertyChangedCommand;
        
        private string answer;

        private DateTime snDate;
        private TimeSpan snTime;

        public CustomControl ControlType { get; set; }
        public string Label { get; set; }

        public string Answer {
            get {
                return answer;
            } set {
                if(answer == value)
                    return;

                answer = value;
                OnPropertyChanged("Answer");
            }
        }

        public DateTime SnDate {
            get {
                return snDate;
            } set {
                if(snDate == value)
                    return;

                snDate = value;
                OnPropertyChanged("SnDate");
            }
        }

        public TimeSpan SnTime {
            get { return snTime; }
            set {
                if(snTime == value)
                {
                    return;
                }

                snTime = value;
                OnPropertyChanged("SnTime");
            }
        }

        public ICommand DateSelectedCommand {
            get {
                return dateSelectedCommand;
            } set {
                if(dateSelectedCommand == value)
                    return;

                dateSelectedCommand = value;
                OnPropertyChanged("DateSelectedCommand");
            }
        }

        public ICommand TimePickerPropertyChangedCommand {
            get { return timePickerPropertyChangedCommand; }
            set {
                if(timePickerPropertyChangedCommand == value)
                {
                    return;
                }

                timePickerPropertyChangedCommand = value;
                OnPropertyChanged("TimePickerPropertyChangedCommand");
            }
        }

        public ICommand DateFocusedCommand {
            get { return dateFocusedCommand; } 
            set {
                if(dateFocusedCommand == value)
                {
                    return;
                }

                dateFocusedCommand = value;
                OnPropertyChanged("DateFocusedCommand");
            }
        }

        public ControlsViewModel()
        {
            DateFocusedCommand = new Command(DateFocused);
            DateSelectedCommand = new Command<string>(s => DateSelectedAnswer(s));
            TimePickerPropertyChangedCommand = new Command<string>(s => TimePickerSetAnswer(s));
        }

        private void TimePickerSetAnswer(string timeString)
        {
            DateTime result;
            if(DateTime.TryParse(timeString, out result))
            {
                this.Answer = result.ToShortTimeString();
            } else
            {
                this.Answer = DateTime.Now.ToShortTimeString();
            }
            
            this.SnTime = ToTimePickerTime(Answer).Value;
        }

        private void DateSelectedAnswer(string dateString)
        {
            DateTime result;
            if(DateTime.TryParse(dateString, out result))
            {
                Answer = dateString;
            } else
            {
                Answer = DateTime.Now.ToShortDateString();
            }
        }

        private void DateFocused()
        {
            SnDate = DateTime.UtcNow;
        }

        private TimeSpan? ToTimePickerTime(string time) {
         
            if (!string.IsNullOrEmpty(time)) {
                DateTime dt;
                bool valid = DateTime.TryParse(time, out dt);
                if(valid) {
                    var dtString = dt.ToString("HH:mm");
                    TimeSpan ts;
                    var validTime = TimeSpan.TryParse(dtString, out ts);
                    if(validTime){
                        return ts;
                    }
                }
            }

            return null;
        }
    }
}
