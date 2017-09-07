﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Houses.Guild
{
    using Utils.IO;

    public class HouseGuildNoneMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5701;
        public override ushort MessageID => ProtocolId;
        public uint HouseId { get; set; }
        public int InstanceId { get; set; }
        public bool SecondHand { get; set; }

        public HouseGuildNoneMessage(uint houseId, int instanceId, bool secondHand)
        {
            HouseId = houseId;
            InstanceId = instanceId;
            SecondHand = secondHand;
        }

        public HouseGuildNoneMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(HouseId);
            writer.WriteInt(InstanceId);
            writer.WriteBoolean(SecondHand);
        }

        public override void Deserialize(IDataReader reader)
        {
            HouseId = reader.ReadVarUhInt();
            InstanceId = reader.ReadInt();
            SecondHand = reader.ReadBoolean();
        }

    }
}
