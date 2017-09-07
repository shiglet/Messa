﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Utils.IO;

    public class MountFeedRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6189;
        public override ushort MessageID => ProtocolId;
        public uint MountUid { get; set; }
        public sbyte MountLocation { get; set; }
        public uint MountFoodUid { get; set; }
        public uint Quantity { get; set; }

        public MountFeedRequestMessage(uint mountUid, sbyte mountLocation, uint mountFoodUid, uint quantity)
        {
            MountUid = mountUid;
            MountLocation = mountLocation;
            MountFoodUid = mountFoodUid;
            Quantity = quantity;
        }

        public MountFeedRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(MountUid);
            writer.WriteSByte(MountLocation);
            writer.WriteVarUhInt(MountFoodUid);
            writer.WriteVarUhInt(Quantity);
        }

        public override void Deserialize(IDataReader reader)
        {
            MountUid = reader.ReadVarUhInt();
            MountLocation = reader.ReadSByte();
            MountFoodUid = reader.ReadVarUhInt();
            Quantity = reader.ReadVarUhInt();
        }

    }
}
