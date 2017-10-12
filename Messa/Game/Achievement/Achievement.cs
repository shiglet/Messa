using Messa.API.Core;
using Messa.API.Game.Achievement;
using Messa.API.Gamedata.D2i;
using Messa.API.Gamedata.D2o;
using Messa.API.Messages;
using Messa.API.Protocol.Network.Messages.Game.Achievement;
using Messa.API.Utils;
using Messa.Core;

namespace Messa.Game.Achievement
{
    public class Achievement : IAchievement
    {
        public Achievement(IAccount account)
        {
            account.Network.RegisterPacket<AchievementFinishedMessage>(HandleAchievementFinishedMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<AchievementRewardSuccessMessage>(HandleAchievementRewardSuccessMessage,
                MessagePriority.VeryHigh);
        }

        private void HandleAchievementFinishedMessage(IAccount account, AchievementFinishedMessage message)
        {
            var text = FastD2IReader.Instance.GetText(ObjectDataManager.Instance
                .Get<API.Datacenter.Achievement>(message.ObjectId).NameId);
            account.Logger.Log($"Succés: {text} Dévérouillé");
            account.Network.SendToServer(new AchievementRewardRequestMessage((short) message.ObjectId));
        }

        private void HandleAchievementRewardSuccessMessage(IAccount account, AchievementRewardSuccessMessage message)
        {
            var text = FastD2IReader.Instance.GetText(ObjectDataManager.Instance
                .Get<API.Datacenter.Achievement>(message.AchievementId).NameId);
            account.Logger.Log($"Succés: {text} Accepté!");
        }
    }
}