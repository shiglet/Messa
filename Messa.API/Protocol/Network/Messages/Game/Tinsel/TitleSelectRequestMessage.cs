﻿namespace Messa.API.Protocol.Network.Messages.Game.Tinsel
{
    using Utils.IO;

    public class TitleSelectRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6365;
        public override ushort MessageID => ProtocolId;
        public ushort TitleId { get; set; }

        public TitleSelectRequestMessage(ushort titleId)
        {
            TitleId = titleId;
        }

        public TitleSelectRequestMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(TitleId);
        }

        public override void Deserialize(IDataReader reader)
        {
            TitleId = reader.ReadVarUhShort();
        }

    }
}
