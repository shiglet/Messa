﻿namespace Messa.API.Protocol.Network.Messages.Game.Social
{
    using Types.Game.Look;
    using Utils.IO;

    public class ContactLookMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5934;
        public override ushort MessageID => ProtocolId;
        public uint RequestId { get; set; }
        public string PlayerName { get; set; }
        public ulong PlayerId { get; set; }
        public EntityLook Look { get; set; }

        public ContactLookMessage(uint requestId, string playerName, ulong playerId, EntityLook look)
        {
            RequestId = requestId;
            PlayerName = playerName;
            PlayerId = playerId;
            Look = look;
        }

        public ContactLookMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(RequestId);
            writer.WriteUTF(PlayerName);
            writer.WriteVarUhLong(PlayerId);
            Look.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            RequestId = reader.ReadVarUhInt();
            PlayerName = reader.ReadUTF();
            PlayerId = reader.ReadVarUhLong();
            Look = new EntityLook();
            Look.Deserialize(reader);
        }

    }
}
