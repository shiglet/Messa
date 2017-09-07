﻿namespace Messa.API.Protocol.Network.Types.Game.Context
{
    using Types.Game.Look;
    using Utils.IO;

    public class GameContextActorInformations : NetworkType
    {
        public const ushort ProtocolId = 150;
        public override ushort TypeID => ProtocolId;
        public double ContextualId { get; set; }
        public EntityLook Look { get; set; }
        public EntityDispositionInformations Disposition { get; set; }

        public GameContextActorInformations(double contextualId, EntityLook look, EntityDispositionInformations disposition)
        {
            ContextualId = contextualId;
            Look = look;
            Disposition = disposition;
        }

        public GameContextActorInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(ContextualId);
            Look.Serialize(writer);
            writer.WriteUShort(Disposition.TypeID);
            Disposition.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            ContextualId = reader.ReadDouble();
            Look = new EntityLook();
            Look.Deserialize(reader);
            Disposition = ProtocolTypeManager.GetInstance<EntityDispositionInformations>(reader.ReadUShort());
            Disposition.Deserialize(reader);
        }

    }
}
