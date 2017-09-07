﻿namespace Messa.API.Protocol.Network.Types.Game.Interactive
{
    using Utils.IO;

    public class InteractiveElementWithAgeBonus : InteractiveElement
    {
        public new const ushort ProtocolId = 398;
        public override ushort TypeID => ProtocolId;
        public short AgeBonus { get; set; }

        public InteractiveElementWithAgeBonus(short ageBonus)
        {
            AgeBonus = ageBonus;
        }

        public InteractiveElementWithAgeBonus() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(AgeBonus);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AgeBonus = reader.ReadShort();
        }

    }
}
