﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Notification
{
    using Utils.IO;

    public class NotificationResetMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6089;
        public override ushort MessageID => ProtocolId;

        public NotificationResetMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
