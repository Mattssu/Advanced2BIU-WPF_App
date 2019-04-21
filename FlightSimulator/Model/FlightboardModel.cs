using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Communication;
using FlightSimulator.ViewModels;

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
        public double Lat { get; }
        public double Lon { get; }
        //run server
        public void Run()
        {
            //
        }
    }
}
