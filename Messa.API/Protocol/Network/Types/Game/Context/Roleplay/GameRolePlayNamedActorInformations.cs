﻿namespace Messa.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Utils.IO;

    public class GameRolePlayNamedActorInformations : GameRolePlayActorInformations
    {
        public new const ushort ProtocolId = 154;
        public override ushort TypeID => ProtocolId;
        public string Name { get; set; }

        public GameRolePlayNamedActorInformations(string name)
        {
            Name = name;
        }

        public GameRolePlayNamedActorInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(Name);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Name = reader.ReadUTF();
        }

    }
}
