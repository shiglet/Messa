using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messa.API.Core;
using Messa.API.Datacenter;
using Messa.API.Game.Bank;
using Messa.API.Messages;
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
        public IAccount Account { get; set; }
        public bool Exited { get; set; }
        public bool ResponseSent { get; set; }
        public bool Finished { get; set; }
        public Bank(IAccount account)
        {
            Account = account;
            Account.Network.RegisterPacket<NpcDialogQuestionMessage>(HandleNpcDialogQuestionMessage,
                MessagePriority.Normal);
            Account.Network.RegisterPacket<StorageInventoryContentMessage>(HandleStorageInventoryContentMessage,
                MessagePriority.Normal);
            Account.Network.RegisterPacket<NpcGenericActionFailureMessage>(HandleNpcGenericActionFailureMessage,
                MessagePriority.Normal);
            Account.Network.RegisterPacket<NpcDialogCreationMessage>(HandleNpcDialogCreationMessage,
                MessagePriority.Normal);
            Account.Network.RegisterPacket<InventoryWeightMessage>(HandleInventoryWeightMessage,
                MessagePriority.Normal);
            
        }

        private void HandleInventoryWeightMessage(IAccount account, InventoryWeightMessage message)
        {
            if(!Finished) return;
            account.Character.Weight = message.Weight;
            account.Character.MaxWeight = message.WeightMax;
            ExitBankDialog();
        }

        private void HandleNpcDialogCreationMessage(IAccount account, NpcDialogCreationMessage message)
        {
        }

        private void HandleNpcGenericActionFailureMessage(IAccount account, NpcGenericActionFailureMessage message)
        {
            account.Logger.Log("NpcGenericActionFailureMessage : ERROR",LogMessageType.Error);
        }
    
        private void HandleStorageInventoryContentMessage(IAccount account, StorageInventoryContentMessage arg2)
        {
            if (Exited) return;
            account.Logger.Log("[Bank] Echange démarré avec le npcBank");
            TransferAllItem();
        }

        private void HandleNpcDialogQuestionMessage(IAccount account, NpcDialogQuestionMessage message)
        {
            if (ResponseSent) return;
            ResponseSent = true;
            ReplyToNpcBank(259);
        }

        public event Action TransfertFinished;

        public void TalkToNcpBank()
        {
            Exited = false;
            ResponseSent = false;
            if (Account.Character.Weight <= 0) return;
            Account.Logger.Log("[Bank] Initalisation du transfert en banque");
            var npc = Account.Character.Map.Npcs.FirstOrDefault();
            if(npc!=null)
                Account.Network.SendToServer(new NpcGenericActionRequestMessage((int)npc.Id,(byte)NpcActionId.TALK,Account.Character.MapId));
            else
                Account.Logger.Log("[Bank] Erreur aucun Npc sur la map ", LogMessageType.Error);
        }

        public void ExitBankDialog()
        {
            Account.Network.SendToServer(new LeaveDialogRequestMessage());
            Exited = true;
            TransfertFinished?.Invoke();
        }

        public void TransferAllItem()
        {
            Account.Logger.Log("[Bank] Transfert de tous les objets dans la banque");
            Account.Network.SendToServer(new ExchangeObjectTransfertAllFromInvMessage());
            Finished = true;
        }

        public void ReplyToNpcBank(uint replyId)
        {
            Account.Logger.Log($"[Bank] Envoie de la réponse {replyId} au npcBank");
            Account.Network.SendToServer(new NpcDialogReplyMessage(replyId));
        }
    }
}
