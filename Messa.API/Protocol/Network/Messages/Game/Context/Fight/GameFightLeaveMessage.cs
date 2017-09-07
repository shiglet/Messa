﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Utils.IO;

    public class GameFightLeaveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 721;
        public override ushort MessageID => ProtocolId;
        public double CharId { get; set; }

        public GameFightLeaveMessage(double charId)
        {
            CharId = charId;
        }

        public GameFightLeaveMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(CharId);
        }

        public override void Deserialize(IDataReader reader)
        {
            CharId = reader.ReadDouble();
        }

    }
}
