﻿namespace Messa.API.Protocol.Network.Types.Game.Context.Fight
{
    using Utils.IO;

    public class FightTeamMemberInformations : NetworkType
    {
        public const ushort ProtocolId = 44;
        public override ushort TypeID => ProtocolId;
        public double ObjectId { get; set; }

        public FightTeamMemberInformations(double objectId)
        {
            ObjectId = objectId;
        }

        public FightTeamMemberInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(ObjectId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectId = reader.ReadDouble();
        }

    }
}
