﻿namespace Messa.API.Protocol.Network.Types.Game.Data.Items.Effects
{
    using Utils.IO;

    public class ObjectEffectDice : ObjectEffect
    {
        public new const ushort ProtocolId = 73;
        public override ushort TypeID => ProtocolId;
        public ushort DiceNum { get; set; }
        public ushort DiceSide { get; set; }
        public ushort DiceConst { get; set; }

        public ObjectEffectDice(ushort diceNum, ushort diceSide, ushort diceConst)
        {
            DiceNum = diceNum;
            DiceSide = diceSide;
            DiceConst = diceConst;
        }

        public ObjectEffectDice() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(DiceNum);
            writer.WriteVarUhShort(DiceSide);
            writer.WriteVarUhShort(DiceConst);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            DiceNum = reader.ReadVarUhShort();
            DiceSide = reader.ReadVarUhShort();
            DiceConst = reader.ReadVarUhShort();
        }

    }
}
