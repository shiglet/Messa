﻿namespace Messa.API.Protocol.Network.Types.Game.Paddock
{
    using Utils.IO;

    public class PaddockBuyableInformations : NetworkType
    {
        public const ushort ProtocolId = 130;
        public override ushort TypeID => ProtocolId;
        public ulong Price { get; set; }
        public bool Locked { get; set; }

        public PaddockBuyableInformations(ulong price, bool locked)
        {
            Price = price;
            Locked = locked;
        }

        public PaddockBuyableInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhLong(Price);
            writer.WriteBoolean(Locked);
        }

        public override void Deserialize(IDataReader reader)
        {
            Price = reader.ReadVarUhLong();
            Locked = reader.ReadBoolean();
        }

    }
}
