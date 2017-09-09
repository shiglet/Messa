using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messa.API.Core;
using Messa.API.Game.Friend;
using Messa.API.Messages;
using Messa.API.Protocol.Enums;
using Messa.API.Protocol.Network.Messages.Game.Friend;
using Messa.API.Utils.Enums;

namespace Messa.Game.Friend
{
    public class Friend : IFriend
    {
        public Friend(IAccount account)
        {
            account.Network.RegisterPacket<FriendsListMessage>(HandleFriendsListMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<FriendDeleteResultMessage>(HandleFriendDeleteResultMessage,
                MessagePriority.VeryHigh);
        }
        private void HandleFriendsListMessage(IAccount account, FriendsListMessage message)
        {
            foreach (var friend in message.FriendsList)
                switch (friend.PlayerState)
                {
                    case (byte)PlayerStateEnum.NOT_CONNECTED:
                        continue;
                    case (byte)PlayerStateEnum.UNKNOWN_STATE:
                        continue;
                    default:
                        account.Logger.Log($"{friend.AccountName} - est connecté(e)");
                        break;
                }
        }

        private void HandleFriendDeleteResultMessage(IAccount account, FriendDeleteResultMessage message)
        {
            if (message.Success)
                account.Logger.Log($"Vous venez de supprimer {message.Name} de votre liste d'ami ",
                    LogMessageType.Info);
            else
                account.Logger.Log($"Erreur lors de la suppresion de l'ami {message.Name}");
        }
    }
}
