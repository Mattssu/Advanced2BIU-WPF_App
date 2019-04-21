using FlightSimulator.Communication;
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ManualModel : BaseNotify
    {
        private Commands commands;
        public ManualModel()
        {
            commands = new Commands();
        }
        public void sendCommand(string data)
        {
            //TODO
        }
    }
}
