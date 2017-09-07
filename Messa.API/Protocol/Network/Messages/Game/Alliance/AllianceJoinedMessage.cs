﻿namespace Messa.API.Protocol.Network.Messages.Game.Alliance
{
    using Types.Game.Context.Roleplay;
    using Utils.IO;

    public class AllianceJoinedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6402;
        public override ushort MessageID => ProtocolId;
        public AllianceInformations AllianceInfo { get; set; }
        public bool Enabled { get; set; }
        public uint LeadingGuildId { get; set; }

        public AllianceJoinedMessage(AllianceInformations allianceInfo, bool enabled, uint leadingGuildId)
        {
            AllianceInfo = allianceInfo;
            Enabled = enabled;
            LeadingGuildId = leadingGuildId;
        }

        public AllianceJoinedMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            AllianceInfo.Serialize(writer);
            writer.WriteBoolean(Enabled);
            writer.WriteVarUhInt(LeadingGuildId);
        }

        public override void Deserialize(IDataReader reader)
        {
            AllianceInfo = new AllianceInformations();
            AllianceInfo.Deserialize(reader);
            Enabled = reader.ReadBoolean();
            LeadingGuildId = reader.ReadVarUhInt();
        }

    }
}
