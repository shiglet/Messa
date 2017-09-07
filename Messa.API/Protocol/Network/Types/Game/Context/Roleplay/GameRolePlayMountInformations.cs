﻿namespace Messa.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Utils.IO;

    public class GameRolePlayMountInformations : GameRolePlayNamedActorInformations
    {
        public new const ushort ProtocolId = 180;
        public override ushort TypeID => ProtocolId;
        public string OwnerName { get; set; }
        public byte Level { get; set; }

        public GameRolePlayMountInformations(string ownerName, byte level)
        {
            OwnerName = ownerName;
            Level = level;
        }

        public GameRolePlayMountInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(OwnerName);
            writer.WriteByte(Level);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            OwnerName = reader.ReadUTF();
            Level = reader.ReadByte();
        }

    }
}
