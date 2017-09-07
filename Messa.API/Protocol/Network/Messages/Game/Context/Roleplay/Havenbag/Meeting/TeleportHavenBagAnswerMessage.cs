﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag.Meeting
{
    using Utils.IO;

    public class TeleportHavenBagAnswerMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6646;
        public override ushort MessageID => ProtocolId;
        public bool Accept { get; set; }

        public TeleportHavenBagAnswerMessage(bool accept)
        {
            Accept = accept;
        }

        public TeleportHavenBagAnswerMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteBoolean(Accept);
        }

        public override void Deserialize(IDataReader reader)
        {
            Accept = reader.ReadBoolean();
        }

    }
}
