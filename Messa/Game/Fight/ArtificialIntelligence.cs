using System;
using System.Collections.Generic;
using System.Linq;
using Messa.API.Core;
using Messa.API.Game.Fight;
using Messa.API.Game.Fight.Fighters;
using Messa.API.Game.Fight.Spells;
using Messa.API.Gamedata;
using Messa.API.Protocol.Network.Messages.Game.Context.Fight;
using Messa.API.Utils;
using Messa.API.Utils.Enums;
//using Messa.Core.Scripts;
using Messa.Game.Fight.Spell;

namespace Messa.Game.Fight
{
    /*public class ArtificialIntelligence : IArtificialIntelligence
    {
        private IAccount _account;

        private IASpell _currentSpell;
        private ISpellCast _spellEvent;
        private List<IASpell> _spells;
        private int _totalSpellLauch;

        public void Load(IAccount account, string path)
        {
            _totalSpellLauch = 0;
            _account = account;
            _spells = ScriptsManager.LoadSpellsFromIA($"{path}.lua");

            var spellsId = _account.Character.Spells.Select(s => s.SpellId).ToList();

            foreach (var spell in _spells)
            {
                if (spellsId.Contains(spell.SpellId)) continue;
                var spellTmp = _spells.FirstOrDefault(s => s.SpellId == spell.SpellId);
                if (spellTmp != null)
                    _spells.Remove(spellTmp);
            }

            /*foreach (var spell in _spells)
            {
                Account.Logger.Log(spell.SpellId.ToString());
            }#1#
            _account.Character.Fight.FightStarted += StartFight;
            _account.Character.Fight.TurnStarted += ExecuteSpell;
            _account.Character.Fight.FightEnded += FightEnd;
        }

        private void FightEnd(GameFightEndMessage msg)
        {
            _account.Character.Fight.FightStarted -= StartFight;
            _account.Character.Fight.TurnStarted -= ExecuteSpell;
            _account.Character.Fight.FightEnded -= FightEnd;
            Account.Logger.Log($"Durée du combat: {TimeSpan.FromMilliseconds(msg.Duration).TotalSeconds} secondes");
        }

        private void StartFight()
        {
            _account.Character.Fight.SetReady();
        }

        private void ExecuteSpell()
        {
            Account.Logger.Log($"Vie du bot: {_account.Character.LifePercentage}");
            if (_spells == null) return;
            var monster = _account.Character.Fight.NearestMonster();
            //foreach (var spell in _spells)
            //{
            var spell = _spells[0];
            _currentSpell = spell;
            var fighter = (IFighter) monster;
            if (spell.Target == SpellTarget.Self)
                fighter = _account.Character.Fight.Fighter;
            var useSpell = _account.Character.Fight.CanUseSpell(spell.SpellId, fighter);
            var nameSpell = D2OParsing.GetSpellName(spell.SpellId);
            if (_totalSpellLauch <= spell.Relaunchs)
            {
                Account.Logger.Log($"Attaque {monster.Name}");
                switch (useSpell)
                {
                    case -1:
                        _account.Character.Fight.EndTurn();
                        break;

                    case 0:
                        Account.Logger.Log($"Lancement de {nameSpell}");
                        _spellEvent = new SpellCast(_account, spell.SpellId, fighter.CellId);
                        _spellEvent.SpellCasted += OnSpellCasted;
                        _spellEvent.PerformCast();
                        break;

                    default:
                        Account.Logger.Log($"Déplacement en {useSpell}");
                        var movement = _account.Character.Fight.MoveToCell(useSpell);
                        movement.MovementFinished += (sender, e) =>
                        {
                            if (e.Sucess)
                            {
                                Account.Logger.Log($"Lancement de {nameSpell}");
                                _spellEvent = new SpellCast(_account, spell.SpellId, fighter.CellId);
                                _spellEvent.SpellCasted += OnSpellCasted;
                                _spellEvent.PerformCast();
                            }
                            else
                            {
                                Account.Logger.Log(
                                    $"Erreur lors du lancement du spell {spell.SpellId} sur la cell {fighter.CellId}",
                                    LogMessageType.Public);
                            }
                        };
                        movement.PerformMovement();
                        break;
                }
            }
            else
            {
                _totalSpellLauch = 0;
                _account.Character.Fight.EndTurn();
            }
        }

        private void OnSpellCasted(object sender, SpellCastEvent e)
        {
            _spellEvent.SpellCasted -= OnSpellCasted;
            if (e.Sucess)
            {
                _totalSpellLauch++;
                if (_totalSpellLauch < _currentSpell.Relaunchs)
                {
                    ExecuteSpell();
                }
                else
                {
                    _totalSpellLauch = 0;
                    _account.Character.Fight.EndTurn();
                }
            }
            else
            {
                _totalSpellLauch = 0;
                _account.Character.Fight.EndTurn();
            }
        }
    }*/
}