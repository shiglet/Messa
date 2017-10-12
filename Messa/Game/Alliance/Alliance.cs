using Messa.API.Core;
using Messa.API.Game.Alliance;
using Messa.API.Messages;
using Messa.API.Protocol.Network.Messages.Game.Alliance;
using Messa.API.Utils;
using Messa.API.Utils.Enums;

namespace Messa.Game.Alliance
{
    public class Alliance : IAlliance
    {
        public Alliance(IAccount account)
        {
            account.Network.RegisterPacket<AllianceMotdMessage>(HandleAllianceMotdMessage, MessagePriority.VeryHigh);
        }

        private void HandleAllianceMotdMessage(IAccount account, AllianceMotdMessage message)
        {
            account.Logger.Log("Annonce d'Alliance : " + message.Content, LogMessageType.Alliance);
        }
    }
}