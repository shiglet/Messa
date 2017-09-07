﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Mount
{
    using Utils.IO;

    public class MountSetXpRatioRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5989;
        public override ushort MessageID => ProtocolId;
        public byte XpRatio { get; set; }

        public MountSetXpRatioRequestMessage(byte xpRatio)
        {
            XpRatio = xpRatio;
        }

        public MountSetXpRatioRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(XpRatio);
        }

        public override void Deserialize(IDataReader reader)
        {
            XpRatio = reader.ReadByte();
        }

    }
}
