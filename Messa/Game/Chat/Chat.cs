using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messa.API.Core;
using Messa.API.Game.Chat;
using Messa.API.Messages;
using Messa.API.Protocol.Enums;
using Messa.API.Protocol.Network.Messages.Game.Chat;
using Messa.API.Utils.Enums;

namespace Messa.Game.Chat
{
    public class Chat : IChat
    {
        public Chat(IAccount account)
        {
            account.Network.RegisterPacket<ChatServerMessage>(HandleChatServerMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ChatErrorMessage>(HandleChatErrorMessage, MessagePriority.VeryHigh);
        }

        private void HandleChatServerMessage(IAccount account, ChatServerMessage message)
        {
            switch ((ChatChannelsMultiEnum)message.Channel)
            {
                case ChatChannelsMultiEnum.CHANNEL_ADMIN:
                    account.Logger.Log("(Admin) " + message.SenderName + " : " + message.Content, LogMessageType.Admin);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_ALLIANCE:
                    account.Logger.Log("(Alliance) " + message.SenderName + " : " + message.Content,
                        LogMessageType.Alliance);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_ARENA:
                    account.Logger.Log("(Kolizéum) " + message.SenderName + " : " + message.Content,
                        LogMessageType.Arena);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_COMMUNITY:
                    account.Logger.Log("(Communauté) " + message.SenderName + " : " + message.Content,
                        LogMessageType.Community);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_GLOBAL:
                    account.Logger.Log("(Général) " + message.SenderName + " : " + message.Content,
                        LogMessageType.Global);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_GUILD:
                    account.Logger.Log("(Guilde) " + message.SenderName + " : " + message.Content,
                        LogMessageType.Guild);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_NOOB:
                    account.Logger.Log("(Débutant) " + message.SenderName + " : " + message.Content,
                        LogMessageType.Noob);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_PARTY:
                    account.Logger.Log("(Groupe) " + message.SenderName + " : " + message.Content,
                        LogMessageType.Party);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_SALES:
                    account.Logger.Log("(Commerce) " + message.SenderName + " : " + message.Content,
                        LogMessageType.Sales);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_SEEK:
                    account.Logger.Log("(Recrutement) " + message.SenderName + " : " + message.Content,
                        LogMessageType.Seek);
                    break;
                case ChatChannelsMultiEnum.CHANNEL_TEAM:
                    account.Logger.Log("(Equipe) " + message.SenderName + " : " + message.Content);
                    break;
                default:
                    account.Logger.Log(message.SenderName + " : " + message.Content, LogMessageType.Sender);
                    break;
            }
        }

        private void HandleChatErrorMessage(IAccount account, ChatErrorMessage message)
        {
            switch ((ChatErrorEnum)message.Reason)
            {
                case ChatErrorEnum.CHAT_ERROR_NO_GUILD:
                    account.Logger.Log("Vous ne possedez pas de guilde.", LogMessageType.Public);
                    break;
                default:
                    account.Logger.Log("Erreur : " + (ChatErrorEnum)message.Reason, LogMessageType.Public);
                    break;
            }
        }
    }
}
