using Messa.API.Core;
using Messa.API.Game.Party;
using Messa.API.Messages;
using Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Party;
using Messa.API.Utils;
using Messa.API.Utils.Enums;

namespace Messa.Game.Party
{
    public class Party : IParty
    {
        public Party(IAccount account)
        {
            account.Network.RegisterPacket<PartyInvitationMessage>(HandlePartyInvitationMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<PartyInvitationCancelledForGuestMessage>(
                HandlePartyInvitationCancelledForGuestMessage, MessagePriority.VeryHigh);
        }

        private void HandlePartyInvitationMessage(IAccount account, PartyInvitationMessage message)
        {
            account.Logger.Log($"Le joueur {message.FromName} vous invite dans son groupe.", LogMessageType.Info);
        }

        private void HandlePartyInvitationCancelledForGuestMessage(IAccount account,
            PartyInvitationCancelledForGuestMessage message)
        {
            account.Logger.Log($"Le joueur id: {message.CancelerId} a annulé son invitation de groupe.",
                LogMessageType.Info);
        }
    }
}