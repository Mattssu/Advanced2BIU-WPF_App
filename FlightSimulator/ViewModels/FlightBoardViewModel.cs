using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Model;
//..lk
using FlightSimulator.Properties;
using System.ComponentModel;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private FlightboardModel model;// = new FlightboardModel();
        //..lk
        private Settings settingsWindow = new Settings();
        public event PropertyChangedEventHandler PropertyChanged;
        public FlightBoardViewModel()
        {
            model = new FlightboardModel(); // check if needs new Info().
        }


        public double Lon
        {
            get;

        }

        public double Lat
        {
            get;

        }
    }
}
