using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Npc;
using Messa.API.Utils.Enums;

namespace Messa.API.Game.Bank
{
    public interface IBank
    {
        event Action TransfertFinished;
        void TalkToNcpBank();

        void ExitBankDialog();

        void TransferAllItem();

        void ReplyToNpcBank(uint replyId);
    }
}
