using FlightSimulator.Communication;
using FlightSimulator.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ManualModel : BaseNotify
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
