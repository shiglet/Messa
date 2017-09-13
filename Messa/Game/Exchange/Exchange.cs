using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messa.API.Core;
using Messa.API.Game.Exchange;
using Messa.API.Messages;
using Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Party;
using Messa.API.Protocol.Network.Messages.Game.Dialog;
using Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges;

namespace Messa.Game.Exchange
{
    public class Exchange : IExchange
    {
        private IAccount Account { get; }
        public Exchange(IAccount account)
        {
            Account = account;
            account.Network.RegisterPacket<ExchangeRequestedTradeMessage>(HandleExchangeRequestedTradeMessage,
                MessagePriority.VeryHigh);
        }

        private void HandleExchangeRequestedTradeMessage(IAccount account, ExchangeRequestedTradeMessage message)
        {
            Task.Delay(100);
            account.Network.SendToServer(new LeaveDialogRequestMessage());
        }
    }
}
