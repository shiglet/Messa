﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Havenbag
{
    using Utils.IO;

    public class HavenBagDailyLoteryMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6644;
        public override ushort MessageID => ProtocolId;
        public byte ReturnType { get; set; }
        public string TokenId { get; set; }

        public HavenBagDailyLoteryMessage(byte returnType, string tokenId)
        {
            ReturnType = returnType;
            TokenId = tokenId;
        }

        public HavenBagDailyLoteryMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(ReturnType);
            writer.WriteUTF(TokenId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ReturnType = reader.ReadByte();
            TokenId = reader.ReadUTF();
        }

    }
}
