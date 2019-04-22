using FlightSimulator.Communication;
using FlightSimulator.ViewModels;
using System.Threading;

namespace FlightSimulator.Model
{
    class AutoPilotModel : BaseNotify
    {
        public void SendCommand(string data)
        {
            if (Commands.Instance.IsConnected)
            {
                new Thread(delegate ()
                {
                    Commands.Instance.SendCommands(data);
                }).Start();
            }
        }
    }
}
