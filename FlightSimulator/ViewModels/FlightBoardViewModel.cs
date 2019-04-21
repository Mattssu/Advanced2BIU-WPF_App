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
using FlightSimulator.Communication;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private FlightboardModel model;// = new FlightboardModel();
        private Settings settingsWindow = new Settings();
        private Info info;
        public FlightBoardViewModel()
        {
            model = new FlightboardModel();
            info = new Info();
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
