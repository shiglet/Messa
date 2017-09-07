﻿namespace Messa.API.Protocol.Network.Messages.Game.Friend
{
    using Utils.IO;

    public class FriendsGetListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 4001;
        public override ushort MessageID => ProtocolId;

        public FriendsGetListMessage() { }

        public override void Serialize(IDataWriter writer)
        {
        }

        public override void Deserialize(IDataReader reader)
        {
        }

    }
}
