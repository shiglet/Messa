using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Messa.API.Core;
using Messa.API.Core.Pathmanager;
using Messa.API.Game.Map;
using Messa.API.Gamedata;
using Messa.API.Gamedata.D2p;
using Messa.API.Messages;
using Messa.API.Protocol.Network.Messages.Game.Context;
using Messa.API.Protocol.Network.Messages.Game.Context.Roleplay;
using Messa.API.Protocol.Network.Messages.Game.Interactive;
using Messa.API.Utils.Enums;
using Messa.Game.Jobs;
using Messa.Game.Map;
using MoonSharp.Interpreter;
using static System.Int32;

namespace Messa.Core.Pathmanager
{
    public class PathManager : IPathManager
    {
        public const string TrajetsDirectory = @"./trajets/";
        private int _maxPods;
        private bool Moved { get; set; }
        public PathManager(IAccount account)
        {
            if (!string.IsNullOrEmpty(TrajetsDirectory) && !Directory.Exists(TrajetsDirectory))
                Directory.CreateDirectory(TrajetsDirectory);

            Launched = false;
            Account = account;
            PathData = new Dictionary<string, Tuple<string, string>>();
            
            Account.Network.RegisterPacket<InteractiveUseErrorMessage>(
                HandleInteractiveUseErrorMessage, MessagePriority.Normal);
            Account.Network.RegisterPacket<GameMapNoMovementMessage>(
                HandleGameMapNoMovementMessage, MessagePriority.Normal);
            Account.Network.RegisterPacket<MapComplementaryInformationsDataMessage>(
                HandleMapComplementaryInformationsDataMessage, MessagePriority.VeryHigh);
        }

        private void HandleMapComplementaryInformationsDataMessage(IAccount account, MapComplementaryInformationsDataMessage message)
        {
            if (!Launched || !Moved) return;
            Moved = false;
            Account.Character.Map.Data = MapsManager.FromId(message.MapId);
            Account.Logger.Log("Appelle de DoAction() après changement de map !!", LogMessageType.Error);
            DoAction();
        }

        private Dictionary<string, Tuple<string, string>> PathData { get; set; }
        private Dictionary<string, Tuple<string, string>> PathDataBank { get; set; }
        private List<int> RessourcesToGather { get; set; }

        public bool Launched { get; set; }

        public bool ReturnBank => Account.Character.WeightPercentage >= _maxPods;
        public IAccount Account { get; set; }


        private int SkillInstanceUid {
            get;
            set;
        }
        private int Id { get; set; }
        private ICellMovement Move { get; set; }
        public async void Start(string trajet)
        {
            RessourcesToGather = new List<int>();
            await Task.Run(() => ParseTrajet(TrajetsDirectory + trajet + ".lua"));
            Launched = true;
            DoAction();
        }

        public void Stop()
        {
            Launched = false;
        }

        public void DoAction()
        {
            if (!Launched || Account.Character.Map.Position == null) return;
            IMapChangement mapChangement = null;
            try
            {
                Tuple<string, string> tuple;
                switch (ReturnBank)
                {
                    case true:
                        tuple = PathDataBank.ContainsKey(Account.Character.Map.Position)
                            ? PathDataBank[Account.Character.Map.Position]
                            : PathDataBank["" + Account.Character.MapId];
                        Account.Logger.Log("Bank",LogMessageType.Admin);
                        break;
                    default:
                        tuple = PathData.ContainsKey(Account.Character.Map.Position)
                            ? PathData[Account.Character.Map.Position]
                            : PathData["" + Account.Character.MapId];
                        Account.Logger.Log("Move", LogMessageType.Admin);
                        break;

                }
                if (tuple != null)
                {
                    switch (tuple.Item2)
                    {
                        case "door":
                            var door = Account.Character.Map.Doors[Convert.ToInt32(tuple.Item1)];
                            Id = (int)door.Id;
                            SkillInstanceUid = (int)door.EnabledSkills[0].SkillInstanceUid;
                            Move = Account.Character.Map.MoveToDoor(Convert.ToInt32(tuple.Item1));
                            Move.MovementFinished += OnMovementFinished;
                            Account.Logger.Log($"Déplacement vers la porte...");
                            Move.PerformMovement();
                            break;
                        case "npcBank":
                            Account.Character.Bank.TalkToNcpBank();
                            break;
                        case "move":
                            Account.Logger.Log($"[PathManager] Déplacement vers {tuple.Item1}",
                                LogMessageType.Info);
                            TryParse(tuple.Item1,out var sun);
                            if(sun==0)
                                mapChangement = Account.Character.Map.ChangeMap(StringToMapDirectionEnum(tuple.Item1));
                            else
                            {
                                Move = Account.Character.Map.MoveToCell(sun);
                                Move.MovementFinished += OnCellMoveFinished;
                                Account.Logger.Log($"Déplacement vers la case {sun}...");
                                Move.PerformMovement();
                            }

                            break;
                        case "gather":
                            if (Account.Character.GatherManager.CanGatherOnMap(RessourcesToGather))
                            {
                                Account.Logger.Log("Lancement de la récolte");
                                Account.Character.GatherManager.Gather(RessourcesToGather, false);
                                break;
                            }
                            Account.Logger.Log("Rien a récolter - Changement de map ");
                            mapChangement = Account.Character.Map.ChangeMap(StringToMapDirectionEnum(tuple.Item1));
                            break;
                        case "fight":
                            Account.Logger.Log("[PathManager] Combat non géré", LogMessageType.Public);
                            mapChangement = Account.Character.Map.ChangeMap(StringToMapDirectionEnum(tuple.Item1));
                            break;
                        default:
                            Account.Logger.Log("[PathManager] Action inconnue", LogMessageType.Public);
                            break;
                    }
                }
                else
                    Account.Logger.Log($"Map {Account.Character.MapId} non gérée dans le trajet");
            }
            catch (Exception e)
            {
                var st = new StackTrace(e, true);
                // Get the top stack frame
                var frame = st.GetFrame(0);
                // Get the line number from the stack frame
                var line = frame.GetFileLineNumber();
                Account.Logger.Log("Problème dans le trajet",LogMessageType.Error);
            }
            if (mapChangement == null) return;
            mapChangement.ChangementFinished += delegate (object sender, MapChangementFinishedEventArgs args)
            {
                Account.Logger.Log($"Changement de map {args.Success}");
                if(Launched)
                {
                    Account.Logger.Log("Lancement de DoAction après changement de map");
                    Account.PerformAction(DoAction, 500);
                }
            };
            mapChangement.PerformChangement();
        }

        private void OnCellMoveFinished(object sender, CellMovementEventArgs e)
        {
            Move.MovementFinished -= OnCellMoveFinished;
            Moved = true;
            Account.Logger.Log($"Déplacement vers la case réussi avec succès.");
        }

        public void OnTransfertFinished()
        {
            DoAction();
        }

        private void OnMovementFinished(object sender, CellMovementEventArgs e)
        {
            Move.MovementFinished -= OnMovementFinished;
            Moved = true;
            Account.Logger.Log($"Déplacement vers la porte réussi avec succès.. Utilisation ..");
            Account.Character.Map.UseElement(Id, SkillInstanceUid);
        }

        private MapDirectionEnum StringToMapDirectionEnum(string dir)
        {
            var direction = MapDirectionEnum.South;
            switch (dir)
            {
                case "top":
                case "up":
                case "haut":
                case "north":
                    direction = MapDirectionEnum.North;
                    break;
                case "bot":
                case "bottom":
                case "bas":
                case "south":
                    direction = MapDirectionEnum.South;
                    break;
                case "left":
                case "gauche":
                case "west":
                    direction = MapDirectionEnum.West;
                    break;
                case "right":
                case "droite":
                case "east":
                    direction = MapDirectionEnum.East;
                    break;
                default:
                    Account.Logger.Log($"Erreur syntaxe  - direction défini sur bas");
                    break;
            }
            return direction;
        }
        private void LoadPath(string type)
        {
            var dyn = _script.Call(_script.Globals[type]);
            var data = new Dictionary<string, Tuple<string, string>>();
            foreach (var item in dyn.Table.Values)
            {
                var map = item.Table.Get("map");
                if (map.IsNil() || map.Type != DataType.String) return;
                
                //define the direction to take
                var direction = "";
                var changeMap = item.Table.Get("changeMap");
                if (changeMap.IsNotNil() && changeMap.Type == DataType.String)
                    direction = changeMap.String;
                //define the action type (Move by default, gather => gather = true, fight => fight = true, door => door="xx", npcBank => npcBank =true)
                var action = "move";
                var gather = item.Table.Get("gather");
                var fight = item.Table.Get("fight");
                var door = item.Table.Get("door");  
                var npcBank = item.Table.Get("npcBank");
                if (gather.IsNotNil())
                    action = "gather";
                else if (fight.IsNotNil())
                    action = "fight";
                else if (door.IsNotNil() && door.Type == DataType.String)
                {
                    action = "door";
                    direction = door.String;//direction is now the DoorId to use
                }
                else if (npcBank.IsNotNil())
                    action = "npcBank";

                data.Add(map.String, Tuple.Create(direction, action));
            }
            switch (type)
            {
                case "bank":
                    PathDataBank = data;
                    break;
                case "move":
                    PathData = data;
                    break;
            }
        }

        private Script _script;
        private void ParseTrajet(string path)
        {
            try
            {
                _maxPods = 101;
                _script = new Script();
                _script.DoFile(path);
                var ressources = _script.Globals.Get("ELEMENTS_TO_GATHER");
                var max = _script.Globals.Get("MAX_PODS");
                LoadPath("move");
                if (max.IsNotNil() && max.Type == DataType.Number)
                {
                    _maxPods = (int) max.Number;
                    LoadPath("bank");
                }
                if (!ressources.IsNotNil()) return;
                foreach (var s in ressources.Table.Values)
                {
                    RessourcesToGather.Add((int) s.Number);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void HandleInteractiveUseErrorMessage(IAccount account, InteractiveUseErrorMessage message)
        {
            account.Logger.Log($"InteractiveUserErrorMessage - Erreur lors de la récolte de la ressource {message.ElemId} sur la cellId : {account.Character.CellId}",LogMessageType.Error);
            if (Launched)
                account.PerformAction(DoAction, 200);
        }

        private void HandleGameMapNoMovementMessage(IAccount account, GameMapNoMovementMessage message)
        {
            account.Logger.Log("Message !!!! GameMapNoMovementMessage !!!!");
            if (Launched)
                account.PerformAction(DoAction, 500);
        }

    }
}
