using Messa.API.Core;
using Messa.API.Game.Guild;
using Messa.API.Messages;
using Messa.API.Protocol.Enums;
using Messa.API.Protocol.Network.Messages.Game.Guild;
using Messa.API.Utils;
using Messa.API.Utils.Enums;

namespace Messa.Game.Guild
{
    public class Guild : IGuild
    {
        public Guild(IAccount account)
        {
            account.Network.RegisterPacket<GuildMotdMessage>(HandleGuildMotdMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<ChallengeFightJoinRefusedMessage>(HandleChallengeFightJoinRefusedMessage,
                MessagePriority.VeryHigh);
        }

        private void HandleGuildMotdMessage(IAccount account, GuildMotdMessage message)
        {
            account.Logger.Log("Annonce de guilde : " + message.Content, LogMessageType.Guild);
        }

        private void HandleChallengeFightJoinRefusedMessage(IAccount account, ChallengeFightJoinRefusedMessage message)
        {
            switch ((FighterRefusedReasonEnum) message.Reason)
            {
                case FighterRefusedReasonEnum.CHALLENGE_FULL:
                    account.Logger.Log("Partie pleine");
                    break;
                case FighterRefusedReasonEnum.AVA_ZONE:
                    account.Logger.Log("Impossible d'agresser en zone de combat d'alliance");
                    break;
                case FighterRefusedReasonEnum.TEAM_FULL:
                    account.Logger.Log("Equipe pleine.");
                    break;
                case FighterRefusedReasonEnum.WRONG_GUILD:
                    account.Logger.Log("Votre guilde ne vous permet pas de faire cette action.");
                    break;
                case FighterRefusedReasonEnum.TOO_LATE:
                    account.Logger.Log("Il est trop tard pour rejoindre ce combat.");
                    break;
                case FighterRefusedReasonEnum.MUTANT_REFUSED:
                    account.Logger.Log("Action impossible lorsque vous êtes transformé en monstre.");
                    break;
                case FighterRefusedReasonEnum.WRONG_MAP:
                    account.Logger.Log("Action impossible sur cette map.");
                    break;
                case FighterRefusedReasonEnum.JUST_RESPAWNED:
                    account.Logger.Log("Impossible de rentrer en combat avec ce joueur car il n'est pas prêt.");
                    break;
                case FighterRefusedReasonEnum.IM_OCCUPIED:
                    account.Logger.Log("Impossible de combatre car vous êtes occupé.");
                    break;
                case FighterRefusedReasonEnum.OPPONENT_OCCUPIED:
                    account.Logger.Log("Impossible de combatre avec ce joueur car il est occupé.");
                    break;
                case FighterRefusedReasonEnum.MULTIACCOUNT_NOT_ALLOWED:
                    account.Logger.Log("Vous ne pouvez pas rejoindre ce combat avec plus d'un compte.");
                    break;
                case FighterRefusedReasonEnum.INSUFFICIENT_RIGHTS:
                    account.Logger.Log("Action impossible en raison des droits des deux joueurs.");
                    break;
                case FighterRefusedReasonEnum.MEMBER_ACCOUNT_NEEDED:
                    account.Logger.Log("Action impossible car votre abonnement a expiré.");
                    break;
                case FighterRefusedReasonEnum.GUEST_ACCOUNT:
                    account.Logger.Log("Action impossible en mode invité.");
                    break;
                case FighterRefusedReasonEnum.OPPONENT_NOT_MEMBER:
                    account.Logger.Log("Action impossible car ce joueur n'a pas un compte membre.");
                    break;
                case FighterRefusedReasonEnum.TEAM_LIMITED_BY_MAINCHARACTER:
                    account.Logger.Log("Impossible de rejoindre le combat (fermé ou limité au groupe.");
                    break;
                case FighterRefusedReasonEnum.GHOST_REFUSED:
                    account.Logger.Log("Une fois mort, les rivalités des vivants paraissent vraiment insignifiantes.");
                    break;
                case FighterRefusedReasonEnum.RESTRICTED_ACCOUNT:
                    account.Logger.Log("Le mode restreint est actif pour la session, cette action est impossible");
                    break;
            }
        }
    }
}