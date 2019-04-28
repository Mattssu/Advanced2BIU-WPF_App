using FlightSimulator.Communication;
using FlightSimulator.ViewModels;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class FlightboardModel : BaseNotify
    {
        private Info info;
        private double lat;
        private double lon;
        //private int bothChanged = 0;
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
                //bool isFirst = true;
                while (info.IsRunning)
                {
                    string[] param = info.ReadData();
                    //todo wait for both at first
                    Lon = Convert.ToDouble(param[0]);
                    Lat = Convert.ToDouble(param[1]);
                }
            }).Start();
        }
    }
}
