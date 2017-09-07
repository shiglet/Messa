using System;

namespace Messa.API.Game.Fight.Spells
{
    public interface ISpellCast
    {
        int SpellId { get; }
        int CellId { get; }

        void PerformCast();

        event EventHandler<SpellCastEvent> SpellCasted;

        event Action Timeout;
    }
}