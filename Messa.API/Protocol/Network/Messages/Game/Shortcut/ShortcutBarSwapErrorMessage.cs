﻿namespace Messa.API.Protocol.Network.Messages.Game.Shortcut
{
    using Utils.IO;

    public class ShortcutBarSwapErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6226;
        public override ushort MessageID => ProtocolId;
        public byte Error { get; set; }

        public ShortcutBarSwapErrorMessage(byte error)
        {
            Error = error;
        }

        public ShortcutBarSwapErrorMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Error);
        }

        public override void Deserialize(IDataReader reader)
        {
            Error = reader.ReadByte();
        }

    }
}
