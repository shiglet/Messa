﻿namespace Messa.API.Protocol.Network.Messages.Game.Guild
{
    using Utils.IO;

    public class GuildHouseRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6180;
        public override ushort MessageID => ProtocolId;
        public uint HouseId { get; set; }
        public int InstanceId { get; set; }
        public bool SecondHand { get; set; }

        public GuildHouseRemoveMessage(uint houseId, int instanceId, bool secondHand)
        {
            HouseId = houseId;
            InstanceId = instanceId;
            SecondHand = secondHand;
        }

        public GuildHouseRemoveMessage() { }

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
