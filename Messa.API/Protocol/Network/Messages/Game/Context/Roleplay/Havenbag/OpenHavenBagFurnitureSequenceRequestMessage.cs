﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    using Utils.IO;

    public class OpenHavenBagFurnitureSequenceRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6635;
        public override ushort MessageID => ProtocolId;

        public OpenHavenBagFurnitureSequenceRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
