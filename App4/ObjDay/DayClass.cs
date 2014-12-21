using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App4.ObjDay
{
    public class DayClass
    {
        public const string DayListPropertyName = "DayList";

        private ObservableCollection<Day> _dayList = null;

        /// <summary>
        /// Sets and gets the DayList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Day> DayList
        {
            get
            {
                return _dayList;
            }

            set
            {
                if (_dayList == value)
                {
                    return;
                }

                //RaisePropertyChanging(DayListPropertyName);
                _dayList = value;
                //RaisePropertyChanged(DayListPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="CurrentDay" /> property's name.
        /// </summary>
        public const string CurrentDayPropertyName = "CurrentDay";

        private Day _currentDay = null;

        /// <summary>
        /// Sets and gets the CurrentDay property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Day CurrentDay
        {
            get
            {
                return _currentDay;
            }

            set
            {
                if (_currentDay == value)
                {
                    return;
                }

                //RaisePropertyChanging(CurrentDayPropertyName);
                _currentDay = value;
                //RaisePropertyChanged(CurrentDayPropertyName);
            }
        }
    }
}
