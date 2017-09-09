using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using Messa.API.Core;
using Messa.API.Core.Frames;
using Messa.API.Core.Network;
using Messa.API.Messages;
using Messa.API.Network;
using Messa.API.Utils.Log;

namespace Messa.Core
{
    public class Account : IAccount
    {
        public Account(string login, string password, IClient connection, MessageDispatcher dispatcher)
        {
            Logger = new Logger();
            Login = login;
            Password = password;

            Network = new Network.Network(this, connection, dispatcher);

            Character = new Character(this);

            //LatencyFrame = new LatencyFrame();
            //BasicFrame = new BasicFrame(this);
           
        }
        public BotView BotView { get; set; }

        public Logger Logger { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public int Id { get; set; }
        public string Ticket { get; set; }
        public string Nickname { get; set; }
        public string SecretQuestion { get; set; }
        public double AccountCreation { get; set; }
        public byte CommunityId { get; set; }
        public double SubscriptionElapsedDuration { get; set; }
        public double SubscriptionEndDate { get; set; }

        public event Action<string, string, string> PacketLogged;
        public ICharacter Character { get; set; }

        public ILatencyFrame LatencyFrame { get; set; }

        public IBasicFrame BasicFrame { get; set; }

        public INetwork Network { get; set; }

        public void LogPacket(string origin, string name, string id)
        {
            PacketLogged?.Invoke(origin, name, id);
        }

        public void PerformAction(Action action, int delay)
        {
            PerformCancelableAction(action, delay);
        }

        public void PerformCancelableAction(Action action, int delay)
        {
            var cts = new CancellationTokenSource();
            Task.Run(async delegate
            {
                await Task.Delay(delay, cts.Token);
                if (!cts.IsCancellationRequested)
                    try
                    {
                        action.Invoke();
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(ex.ToString());
                    }
            }, cts.Token);
        }
    }
}
