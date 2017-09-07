﻿namespace Messa.API.Protocol.Network.Types.Game.Guild.Tax
{
    using Utils.IO;

    public class AdditionalTaxCollectorInformations : NetworkType
    {
        public const ushort ProtocolId = 165;
        public override ushort TypeID => ProtocolId;
        public string CollectorCallerName { get; set; }
        public int Date { get; set; }

        public AdditionalTaxCollectorInformations(string collectorCallerName, int date)
        {
            CollectorCallerName = collectorCallerName;
            Date = date;
        }

        public AdditionalTaxCollectorInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteUTF(CollectorCallerName);
            writer.WriteInt(Date);
        }

        public override void Deserialize(IDataReader reader)
        {
            CollectorCallerName = reader.ReadUTF();
            Date = reader.ReadInt();
        }

    }
}
