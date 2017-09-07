﻿namespace Messa.API.Protocol.Network.Messages.Game.Actions.Fight
{
    using Messages.Game.Actions;
    using Utils.IO;

    public class GameActionFightReflectDamagesMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5530;
        public override ushort MessageID => ProtocolId;
        public double TargetId { get; set; }

        public GameActionFightReflectDamagesMessage(double targetId)
        {
            TargetId = targetId;
        }

        public GameActionFightReflectDamagesMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
        }

    }
}
