using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulator.Communication;
namespace FlightSimulator.Model
{
    class FlightboardModel
    {
        // lk
        private Info info ;
        public event PropertyChangedEventHandler PropertyChanged;
        public FlightboardModel(){ this.info = info;}
        // to finish , check if needs lon and lat.
         public void NotifyPropertyChanged(string proertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(proertyName));
        }
    }
}
