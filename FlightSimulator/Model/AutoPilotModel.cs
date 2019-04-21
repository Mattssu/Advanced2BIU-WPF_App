using FlightSimulator.Communication;
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class AutoPilotModel : BaseNotify
    {
        private Commands commands;

        public AutoPilotModel()
        {
            //Fix server
            commands = new Commands();
        }

        public void sendCommands(string data)
        {
            //send commands to Commands client
        }
    }
}
