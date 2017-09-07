﻿namespace Messa.API.Protocol.Network.Messages.Secure
{
    using Utils.IO;

    public class TrustStatusMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6267;
        public override ushort MessageID => ProtocolId;
        public bool Trusted { get; set; }
        public bool Certified { get; set; }

        public TrustStatusMessage(bool trusted, bool certified)
        {
            Trusted = trusted;
            Certified = certified;
        }

        public TrustStatusMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, Trusted);
            flag = BooleanByteWrapper.SetFlag(1, flag, Certified);
            writer.WriteByte(flag);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            Trusted = BooleanByteWrapper.GetFlag(flag, 0);
            Certified = BooleanByteWrapper.GetFlag(flag, 1);
        }

    }
}
