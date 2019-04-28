using System;
//..lk
using System.ComponentModel;
using FlightSimulator.Model;
using FlightSimulator.Views.Windows;
using System.Windows.Input;
using System.Threading;
using FlightSimulator.Communication;
using System.Diagnostics;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private FlightboardModel model;
        private SettingsView settingsWindow = new SettingsView();
        #region Lat&Lon Logic
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
        #endregion
        #region connectButton
        private ICommand connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return connectCommand ?? (connectCommand = new CommandHandler(() =>
               {
                   new Thread(delegate ()
                   {
                       //start instance of Commands client
                       Commands.Instance.Connect(ApplicationSettingsModel.Instance.FlightServerIP, ApplicationSettingsModel.Instance.FlightCommandPort);
                   }).Start();
                   //start Info Server
                   model.Run(ApplicationSettingsModel.Instance.FlightServerIP, ApplicationSettingsModel.Instance.FlightInfoPort);

               }));
            }
        }
        #endregion
        #region settingsButton
        private ICommand settingsCommand;
        public ICommand SettingsCommand
        {
            get
            {
                return settingsCommand ?? (settingsCommand = new CommandHandler(() =>
                {
                    settingsWindow = new SettingsView();
                    settingsWindow.Show();
                }));
            }
        }
        #endregion
    }
}
