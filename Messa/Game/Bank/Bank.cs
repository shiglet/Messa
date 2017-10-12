using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messa.API.Core;
using Messa.API.Datacenter;
using Messa.API.Game.Bank;
using Messa.API.Messages;
using Messa.API.Protocol.Enums;
using Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Npc;
using Messa.API.Protocol.Network.Messages.Game.Dialog;
using Messa.API.Protocol.Network.Messages.Game.Inventory.Exchanges;
using Messa.API.Protocol.Network.Messages.Game.Inventory.Items;
using Messa.API.Protocol.Network.Messages.Game.Inventory.Storage;
using Messa.API.Utils;
using Messa.API.Utils.Enums;
using Messa.Core;

namespace Messa.Game.Bank
{
    public class Bank : IBank
    {
        private IAccount Account { get; set; }
        private bool TransfertItemFinished { get; set; }
        private bool InDialog { get; set; }
        private bool InExchange { get; set; }
        public event Action TransfertFinished;

        public Bank(IAccount account)
        {
            Account = account;
            Account.Network.RegisterPacket<NpcDialogQuestionMessage>(HandleNpcDialogQuestionMessage,
                MessagePriority.Normal);
            Account.Network.RegisterPacket<StorageInventoryContentMessage>(HandleStorageInventoryContentMessage,
                MessagePriority.Normal);
            Account.Network.RegisterPacket<NpcGenericActionFailureMessage>(HandleNpcGenericActionFailureMessage,
                MessagePriority.Normal);
            Account.Network.RegisterPacket<InventoryWeightMessage>(HandleInventoryWeightMessage,
                MessagePriority.Normal);
            Account.Network.RegisterPacket<ExchangeLeaveMessage>(HandleExchangeLeaveMessage, MessagePriority.VeryHigh);
            Account.Network.RegisterPacket<ExchangeStartedWithStorageMessage>(HandleExchangeStartedWithStorageMessage, MessagePriority.VeryHigh);
        }


        public void TalkToNcpBank()
        {
            if (Account.Character.Weight <= 0) return;
            Account.Logger.Log("[Bank] Initalisation du transfert en banque");
            var npc = Account.Character.Map.Npcs.FirstOrDefault();
            if (npc != null)
                Account.Network.SendToServer(new NpcGenericActionRequestMessage((int)npc.Id, (byte)NpcActionId.TALK, Account.Character.MapId));
            else
                Account.Logger.Log("[Bank] Erreur aucun Npc sur la map ", LogMessageType.Error);
        }


        private void HandleNpcDialogQuestionMessage(IAccount account, NpcDialogQuestionMessage message)
        {
            if (InDialog) return;
            InDialog = true;
            ReplyToNpcBank(259);
        }
        public void ReplyToNpcBank(uint replyId)
        {
            Account.Logger.Log($"[Bank] Envoie de la réponse {replyId} au npcBank");
            Account.Network.SendToServer(new NpcDialogReplyMessage(replyId));
        }




        private void HandleExchangeStartedWithStorageMessage(IAccount account, ExchangeStartedWithStorageMessage message)
        {
            if (message.ExchangeType != (byte) ExchangeTypeEnum.BANK|| !InDialog) return;
            InDialog = false;
            InExchange = true;
        }
        private void HandleInventoryWeightMessage(IAccount account, InventoryWeightMessage message)
        {
            if (!TransfertItemFinished || !InExchange) return;
            TransfertItemFinished = false;
            account.Character.Weight = message.Weight;
            account.Character.MaxWeight = message.WeightMax;
            ExitBankDialog();
        }
        private void HandleStorageInventoryContentMessage(IAccount account, StorageInventoryContentMessage arg2)
        {
            if (!InExchange) return;
            account.Logger.Log("[Bank] Echange démarré avec le npcBank");
            TransferAllItem();
        }
        public void TransferAllItem()
        {
            Account.Logger.Log("[Bank] Transfert de tous les objets dans la banque");
            Account.Network.SendToServer(new ExchangeObjectTransfertAllFromInvMessage());
            TransfertItemFinished = true;
        }




        private void HandleExchangeLeaveMessage(IAccount account, ExchangeLeaveMessage message)
        {
            if (!InExchange) return;
            InExchange = false;
            TransfertFinished?.Invoke();
        }
        private void HandleNpcGenericActionFailureMessage(IAccount account, NpcGenericActionFailureMessage message)
        {
            account.Logger.Log("NpcGenericActionFailureMessage : ERROR",LogMessageType.Error);
            InDialog = false;
            TransfertItemFinished = false;
            InExchange = false;
        }
        public void ExitBankDialog()
        {
            Account.Network.SendToServer(new LeaveDialogRequestMessage());
        }
    }
}
