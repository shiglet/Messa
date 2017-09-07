﻿namespace Messa.API.Protocol.Network.Messages.Game.Friend
{
    using Utils.IO;

    public class GuildMemberSetWarnOnConnectionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6159;
        public override ushort MessageID => ProtocolId;
        public bool Enable { get; set; }

        public GuildMemberSetWarnOnConnectionMessage(bool enable)
        {
            Enable = enable;
        }

        public GuildMemberSetWarnOnConnectionMessage() { }

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
