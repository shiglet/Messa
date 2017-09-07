﻿namespace Messa.API.Protocol.Network.Messages.Game.Friend
{
    using Utils.IO;

    public class FriendSetWarnOnLevelGainMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6077;
        public override ushort MessageID => ProtocolId;
        public bool Enable { get; set; }

        public FriendSetWarnOnLevelGainMessage(bool enable)
        {
            Enable = enable;
        }

        public FriendSetWarnOnLevelGainMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Enable);
        }

        public override void Deserialize(IDataReader reader)
        {
            Enable = reader.ReadBoolean();
        }

    }
}
