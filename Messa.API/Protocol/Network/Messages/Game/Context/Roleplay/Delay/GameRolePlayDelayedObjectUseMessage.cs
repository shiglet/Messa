﻿namespace Messa.API.Protocol.Network.Messages.Game.Context.Roleplay.Delay
{
    using Utils.IO;

    public class GameRolePlayDelayedObjectUseMessage : GameRolePlayDelayedActionMessage
    {
        public new const ushort ProtocolId = 6425;
        public override ushort MessageID => ProtocolId;
        public ushort ObjectGID { get; set; }

        public GameRolePlayDelayedObjectUseMessage(ushort objectGID)
        {
            ObjectGID = objectGID;
        }

        public GameRolePlayDelayedObjectUseMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(ObjectGID);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            ObjectGID = reader.ReadVarUhShort();
        }

    }
}
