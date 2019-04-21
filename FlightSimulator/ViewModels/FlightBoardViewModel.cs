using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
//..lk
using FlightSimulator.Properties;
using System.ComponentModel;
using FlightSimulator.Communication;
using System.Windows.Input;
using FlightSimulator.Views.Windows;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private FlightboardModel model;
        private SettingsView settingsWindow = new SettingsView();
        //constructor
        public FlightBoardViewModel()
        {
            model = new FlightboardModel();
            //to keep track of updates
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "Lat")
                {
                    Lat = model.Lat;
                }
                else if (e.PropertyName == "Lon")
                {
                    Lon = model.Lon;
                }
                //notify of update
                NotifyPropertyChanged(e.PropertyName);
            };
        }
        //properties
        public double Lon
        {
            get;
            set;

        }
        public double Lat
        {
            get;
            set;

        }
        #region connectButton
        private ICommand connectButton;
        public ICommand ConnectButton
        {
            get
            {
                return connectButton ?? (connectButton = new CommandHandler(() =>
               {
                   model.Run();
               }));
            }
        }
        #endregion
        #region settingsButton
        private ICommand settingsButton;
        public ICommand SettingsButton
        {
            get
            {
                return settingsButton ?? (settingsButton = new CommandHandler(() =>
                {
                    if (!settingsWindow.IsLoaded)
                    {
                        settingsWindow = new SettingsView();
                        settingsWindow.Show();
                    }
                    else
                    {
                        settingsWindow.Show();
                    }
                }));
            }
        }
        #endregion
    }
}
