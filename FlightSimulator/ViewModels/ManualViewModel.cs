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
        private readonly string rudderePath = " /controls/flight/rudder ";
        private readonly string aileronPath = " /controls/flight/aileron ";
        private readonly string elevatorPath = " /controls/flight/elevator ";
    }
}
