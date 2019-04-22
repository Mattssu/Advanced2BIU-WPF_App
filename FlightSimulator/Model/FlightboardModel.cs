using FlightSimulator.Communication;
using FlightSimulator.ViewModels;
using System;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class FlightboardModel : BaseNotify
    {
        private Info info;
        private double lat;
        private double lon;
        //constructor
        public FlightboardModel()
        {
            this.info = new Info();
        }
        //properties
        public double Lat
        {
            get
            {
                return lat;
            }
            set
            {
                lat = value;
                NotifyPropertyChanged("Lat");
            }
        }
        public double Lon
        {
            get
            {
                return lon;
            }
            set
            {
                lon = value;
                NotifyPropertyChanged("Lon");
            }
        }
        //run server
        public void Run(string ip, int port)
        {
            info.Connect(ip, port);
            Reader();
        }
        public void Reader()
        {
            new Task(delegate ()
            {
                while (!info.IsRunning)
                {
                    string[] param = info.ReadData();
                    Lon = Convert.ToDouble(param[0]);
                    Lat = Convert.ToDouble(param[1]);
                }
            }).Start();
        }
        public bool IsRunning()
        {
            return info.IsRunning;
        }
        public void TurnOff()
        {
            info.Disconnect();
        }
    }
}
