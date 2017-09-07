using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Messa.Core;

namespace Messa.ViewModels
{
    internal class BotViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Packet> PacketList { get; }
        public ObservableCollection<LogMessage> Logs { get; }
        private Account Account { get; }

        public BotViewModel(Account account)
        {
            PacketList = new ObservableCollection<Packet>();
            Logs = new ObservableCollection<LogMessage>();
            Account = account;
            Account.Logger.OnLog += Logger_OnLog;
            Account.PacketLogged += OnPacketLogged;
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

        private void Logger_OnLog(string log)
        {
            //RichTextBox.Dispatcher.Invoke(() =>
            //{
            //    TextRange rangeOfText2 = new TextRange(RichTextBox.Document.ContentEnd, RichTextBox.Document.ContentEnd);
            //    rangeOfText2.Text = $"[{DateTime.Now.ToLongTimeString()}] - {log}\n";
            //    rangeOfText2.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.DarkBlue);
            //    RichTextBox.ScrollToEnd();
            //});
            Application.Current.Dispatcher.Invoke(() =>
            {
                Logs.Add(new LogMessage(log));
            });
        }
    }

    internal class LogMessage
    {

        public string Message { get; set; }
        public Brush Color { get; set; }


        public LogMessage(string message) // Add log type here and set the color of the log based on the type
        {
            Message = message;
            Color = Brushes.DarkBlue; // Default
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
