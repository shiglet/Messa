﻿namespace Messa.API.Protocol.Network.Types.Game.Character
{
    using Types.Game.Look;
    using Utils.IO;

    public class CharacterMinimalPlusLookInformations : CharacterMinimalInformations
    {
        public new const ushort ProtocolId = 163;
        public override ushort TypeID => ProtocolId;
        public EntityLook EntityLook { get; set; }

        public CharacterMinimalPlusLookInformations(EntityLook entityLook)
        {
            EntityLook = entityLook;
        }

        public CharacterMinimalPlusLookInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            EntityLook.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            EntityLook = new EntityLook();
            EntityLook.Deserialize(reader);
        }

    }
}
