﻿namespace Messa.API.Protocol.Network.Messages.Game.Actions.Fight
{
    using Messages.Game.Actions;
    using Utils.IO;

    public class GameActionFightActivateGlyphTrapMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 6545;
        public override ushort MessageID => ProtocolId;
        public short MarkId { get; set; }
        public bool Active { get; set; }

        public GameActionFightActivateGlyphTrapMessage(short markId, bool active)
        {
            MarkId = markId;
            Active = active;
        }

        public GameActionFightActivateGlyphTrapMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(MarkId);
            writer.WriteBoolean(Active);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MarkId = reader.ReadShort();
            Active = reader.ReadBoolean();
        }

    }
}
