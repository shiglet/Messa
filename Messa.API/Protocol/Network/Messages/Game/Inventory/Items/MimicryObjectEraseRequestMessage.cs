﻿namespace Messa.API.Protocol.Network.Messages.Game.Inventory.Items
{
    using Utils.IO;

    public class MimicryObjectEraseRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6457;
        public override ushort MessageID => ProtocolId;
        public uint HostUID { get; set; }
        public byte HostPos { get; set; }

        public MimicryObjectEraseRequestMessage(uint hostUID, byte hostPos)
        {
            HostUID = hostUID;
            HostPos = hostPos;
        }

        public MimicryObjectEraseRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(HostUID);
            writer.WriteByte(HostPos);
        }

        public override void Deserialize(IDataReader reader)
        {
            HostUID = reader.ReadVarUhInt();
            HostPos = reader.ReadByte();
        }

    }
}
