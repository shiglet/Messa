﻿namespace Messa.API.Protocol.Network.Messages.Game.Friend
{
    using Types.Game.Friend;
    using System.Collections.Generic;
    using Utils.IO;

    public class FriendsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 4002;
        public override ushort MessageID => ProtocolId;
        public List<FriendInformations> FriendsList { get; set; }

        public FriendsListMessage(List<FriendInformations> friendsList)
        {
            FriendsList = friendsList;
        }

        public FriendsListMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)FriendsList.Count);
            for (var friendsListIndex = 0; friendsListIndex < FriendsList.Count; friendsListIndex++)
            {
                var objectToSend = FriendsList[friendsListIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var friendsListCount = reader.ReadUShort();
            FriendsList = new List<FriendInformations>();
            for (var friendsListIndex = 0; friendsListIndex < friendsListCount; friendsListIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<FriendInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                FriendsList.Add(objectToAdd);
            }
        }

    }
}
