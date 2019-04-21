using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class ManualViewModel : BaseNotify
    {
        private ManualModel model = new ManualModel();
        //Paths to appropriate data in the Simulator
        private readonly string throttlePath = " /controls/engines/current-engine/throttle ";
        private readonly string rudderPath = " /controls/flight/rudder ";
        private readonly string aileronPath = " /controls/flight/aileron ";
        private readonly string elevatorPath = " /controls/flight/elevator ";
        //get and set (uses model to send)
        public double Throttle
        {
            set
            {
                model.sendCommand("set" + throttlePath + Convert.ToString(value));
            }
        }
        public double Rudder
        {
            set
            {
                model.sendCommand("set" + rudderPath + Convert.ToString(value));
            }
        }
        public double Aileron
        {
            set
            {
                model.sendCommand("set" + aileronPath + Convert.ToString(value));
            }
        }
        public double Elevetor
        {
            set
            {
                model.sendCommand("set" + elevatorPath + Convert.ToString(value));
            }
        }
    }
}
