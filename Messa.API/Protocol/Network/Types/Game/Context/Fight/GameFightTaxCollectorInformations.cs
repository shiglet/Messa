﻿namespace Messa.API.Protocol.Network.Types.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightTaxCollectorInformations : GameFightAIInformations
    {
        public new const ushort ProtocolId = 48;
        public override ushort TypeID => ProtocolId;
        public ushort FirstNameId { get; set; }
        public ushort LastNameId { get; set; }
        public byte Level { get; set; }

        public GameFightTaxCollectorInformations(ushort firstNameId, ushort lastNameId, byte level)
        {
            FirstNameId = firstNameId;
            LastNameId = lastNameId;
            Level = level;
        }

        public GameFightTaxCollectorInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(FirstNameId);
            writer.WriteVarUhShort(LastNameId);
            writer.WriteByte(Level);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            FirstNameId = reader.ReadVarUhShort();
            LastNameId = reader.ReadVarUhShort();
            Level = reader.ReadByte();
        }

    }
}
