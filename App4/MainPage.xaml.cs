using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using Windows.UI.Popups;
using Windows.Devices.Geolocation;
using System.Collections.ObjectModel;


namespace App4
{
    
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// The <see cref="DayList" /> property's name.
        /// </summary>
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

        //DayList 

        Geolocator geo = null;


        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
           
        }

        private async void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    pbWeather.Visibility = Visibility.Visible;
                    client.BaseAddress = new Uri("http://api.openweathermap.org/");
                    //Сделать проверку на сохраненные данные и впиливать их вместо txtPincode.
                    var url = "data/2.5/forecast/daily?q=" + txtPincode.Text + "&lat=0&lon=0&cnt=10&mode=json&units=metric";

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage resp = await client.GetAsync(String.Format(url, txtPincode.Text));

                    if (resp.IsSuccessStatusCode)
                    {
                        var data = resp.Content.ReadAsStringAsync();
                        var weatherData = JsonConvert.DeserializeObject<RootObject>(data.Result.ToString());

                        spWeatherInfo.DataContext = weatherData;
                    }

                    pbWeather.Visibility = Visibility.Collapsed;
                    
                }
            }

            catch(Exception ex)
            {
                MessageDialog dialog = new MessageDialog(ex.Message);
                dialog.ShowAsync();
                pbWeather.Visibility = Visibility.Collapsed;
            }

            AddCity.Visibility = Visibility.Collapsed;
        }

        private void location_Click(object sender, RoutedEventArgs e)
        {
            AddCity.Visibility = Visibility.Visible;
        }

        private async void refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    pbWeather.Visibility = Visibility.Visible;
                    client.BaseAddress = new Uri("http://api.openweathermap.org/");
                    //Вместо txtPincode впихнуть сохраненные данные!
                    var url = "data/2.5/forecast/daily?q=" + txtPincode.Text + "&lat=0&lon=0&cnt=10&mode=json&units=metric"; 

                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage resp = await client.GetAsync(String.Format(url, txtPincode.Text));

                    if (resp.IsSuccessStatusCode)
                    {
                        var data = resp.Content.ReadAsStringAsync();
                        var weatherData = JsonConvert.DeserializeObject<RootObject>(data.Result.ToString());

                        spWeatherInfo.DataContext = weatherData;
                    }

                    pbWeather.Visibility = Visibility.Collapsed;

                }
            }

            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog(ex.Message);
                dialog.ShowAsync();
                pbWeather.Visibility = Visibility.Collapsed;
            }
        }

        private void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
            
        } 
    }
}
