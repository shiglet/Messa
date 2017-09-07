﻿namespace Messa.API.Protocol.Network.Types.Game.Character
{
    using Types.Game.Context.Roleplay;
    using Utils.IO;

    public class CharacterMinimalGuildInformations : CharacterMinimalPlusLookInformations
    {
        public new const ushort ProtocolId = 445;
        public override ushort TypeID => ProtocolId;
        public BasicGuildInformations Guild { get; set; }

        public CharacterMinimalGuildInformations(BasicGuildInformations guild)
        {
            Guild = guild;
        }

        public CharacterMinimalGuildInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Guild.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Guild = new BasicGuildInformations();
            Guild.Deserialize(reader);
        }

    }
}
