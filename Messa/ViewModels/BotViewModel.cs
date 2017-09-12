using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Messa.API.Utils.Enums;
using Messa.Core;

namespace Messa.ViewModels
{
    internal class BotViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Packet> PacketList { get; }
        public ObservableCollection<LogMessage> Logs { get; }
        private Account Account { get; }
        public ICommand Gather { get; set; }

        public BotViewModel(Account account)
        {
            PacketList = new ObservableCollection<Packet>();
            Logs = new ObservableCollection<LogMessage>();
            Account = account;
            Account.Logger.OnLog += Logger_OnLog;
            Account.PacketLogged += OnPacketLogged;
            Gather = new RelayCommand.RelayCommand(o =>
            {
                Account.Character.PathManager.Start("incarnam");
            });
        }

        private void OnPacketLogged(string origin, string name, string id)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                PacketList.Add(new Packet(origin, name, id));
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Logger_OnLog(string log, LogMessageType type)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                Brush color;
                BrushConverter brushConverter = new BrushConverter();
                switch (type)
                {
                    case LogMessageType.Global:
                        color = (Brush)brushConverter.ConvertFromString("#E9E9E9");
                        break;
                    case LogMessageType.Team:
                        color = (Brush)brushConverter.ConvertFromString("#FF006C");
                        break;
                    case LogMessageType.Guild:
                        color = (Brush)brushConverter.ConvertFromString("#975FFF");
                        break;
                    case LogMessageType.Alliance:
                        color = (Brush)brushConverter.ConvertFromString("#FFAD42");
                        break;
                    case LogMessageType.Party:
                        color = (Brush)brushConverter.ConvertFromString("#00E4FF");
                        break;
                    case LogMessageType.Sales:
                        color = (Brush)brushConverter.ConvertFromString("#B3783E");
                        break;
                    case LogMessageType.Seek:
                        color = (Brush)brushConverter.ConvertFromString("#E4A0D5");
                        break;
                    case LogMessageType.Noob:
                        color = (Brush)brushConverter.ConvertFromString("#D3AA07");
                        break;
                    case LogMessageType.Admin:
                        color = (Brush)brushConverter.ConvertFromString("#FF00FF");
                        break;
                    case LogMessageType.Private:
                        color = (Brush)brushConverter.ConvertFromString("#7EC3FF");
                        break;
                    case LogMessageType.Info:
                        color = (Brush)brushConverter.ConvertFromString("#46A324");
                        break;
                    case LogMessageType.FightLog:
                        color = (Brush)brushConverter.ConvertFromString("#9DFF00");
                        break;
                    case LogMessageType.Public:
                        color = (Brush)brushConverter.ConvertFromString("#EF3A3E");
                        break;
                    case LogMessageType.Arena:
                        color = (Brush)brushConverter.ConvertFromString("#F16392");
                        break;
                    case LogMessageType.Community:
                        color = (Brush)brushConverter.ConvertFromString("#9EC79D");
                        break;
                    case LogMessageType.Sender:
                        color = (Brush)brushConverter.ConvertFromString("#1B96FF");
                        break;
                    case LogMessageType.Default:
                        color = (Brush)brushConverter.ConvertFromString("#E8890D");
                        break;
                    case LogMessageType.Divers:
                        color = (Brush)brushConverter.ConvertFromString("#3498db");
                        break;
                    case LogMessageType.Error:
                        color = (Brush)brushConverter.ConvertFromString("#FF0033");
                        break;
                    case LogMessageType.Help:
                        color = (Brush)brushConverter.ConvertFromString("#2DB796");
                        break;
                    case LogMessageType.Command:
                        color = (Brush)brushConverter.ConvertFromString("#969696");
                        break;
                    default:
                        color = (Brush)brushConverter.ConvertFromString("#E8890D");
                        break;
                }
                Logs.Add(new LogMessage($"[{DateTime.Now.TimeOfDay}] - {log}",color));
            });
        }
    }

    internal class LogMessage
    {

        public string Message { get; set; }
        public Brush Color { get; set; }


        public LogMessage(string message,Brush c) // Add log type here and set the color of the log based on the type
        {
            Message = message;
            Color = c;
        }

    }

    internal class Packet
    {
        public string Origin { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        internal Packet(string origin, string name, string id)
        {
            Origin = origin;
            Name = name;
            Id = id;
        }
    }
}
