﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
//
using FlightSimulator.Model;

namespace FlightSimulator.ViewModels
{
    class AutoPilotViewModel : BaseNotify
    {
        //init
        private AutoPilotModel model;
        private string commandsToSend;
        private Brush backgroundColor = Brushes.White;
        //properties
        public string CommandsToSend
        {
            get { return commandsToSend; }
            set
            {
                commandsToSend = value;
                if (!string.IsNullOrEmpty(CommandsToSend) && BackgroundColor == Brushes.White)
                {
                    BackgroundColor = Brushes.LightSalmon;
                }
                else if (string.IsNullOrEmpty(CommandsToSend))
                {
                    BackgroundColor = Brushes.White;
                }
            }
        }
        public Brush BackgroundColor
        {
            get { return backgroundColor; }
            set
            {
                backgroundColor = value;
                NotifyPropertyChanged("Background");
            }
        }
        //constructor
        public AutoPilotViewModel()
        {
            model = new AutoPilotModel();
        }
        #region okButton
        private ICommand okCommand;
        public ICommand OkCommand
        {
            get
            {
                return okCommand ?? (okCommand = new CommandHandler(() =>
                {
                    //reset view
                    string sendText = CommandsToSend;
                    CommandsToSend = "";
                    NotifyPropertyChanged(CommandsToSend);
                    //sends the commands & reset color
                    model.sendCommands(sendText);
                    BackgroundColor = Brushes.White;
                }));
            }
        }
        #endregion
        #region clearButton
        private ICommand clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return clearCommand ?? (clearCommand = new CommandHandler(() =>
                {
                    //reset view
                    CommandsToSend = "";
                    NotifyPropertyChanged(CommandsToSend);
                    BackgroundColor = Brushes.White;
                }));
            }
        }
        #endregion

    }
}
