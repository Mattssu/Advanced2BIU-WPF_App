using System;
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

        //sets the value (no need to get)
        public double Throttle
        {
            set { model.SendCommand("set" + throttlePath + Convert.ToString(value)); }
        }
        public double Rudder
        {
            set { model.SendCommand("set" + rudderPath + Convert.ToString(value)); }
        }
        public double Aileron
        {
            set { model.SendCommand("set" + aileronPath + Convert.ToString(value)); }
        }
        public double Elevetor
        {
            set { model.SendCommand("set" + elevatorPath + Convert.ToString(value)); }
        }
    }
}
