using Messa.API.Protocol.Network.Types.Game.Context.Roleplay;

namespace Messa.API.Game.Entity
{
    public interface IMonsterGroup : IEntity
    {
        GroupMonsterStaticInformations StaticInfos { get; }

        int MonstersCount { get; }

        int GroupLevel { get; }

        string GroupName { get; }
    }
}