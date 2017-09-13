using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Messa.API.Core;
using Messa.API.Core.Pathmanager;
using Messa.API.Game.Map;
using Messa.API.Gamedata;
using Messa.API.Messages;
using Messa.API.Protocol.Network.Messages.Game.Context;
using Messa.API.Protocol.Network.Messages.Game.Context.Roleplay;
using Messa.API.Protocol.Network.Messages.Game.Interactive;
using Messa.API.Utils.Enums;
using Messa.Game.Map;
using MoonSharp.Interpreter;

namespace Messa.Core.Pathmanager
{
    public class PathManager : IPathManager
    {
        public const string TrajetsDirectory = @"./trajets/";

        public PathManager(IAccount account)
        {
            if (!string.IsNullOrEmpty(TrajetsDirectory) && !Directory.Exists(TrajetsDirectory))
                Directory.CreateDirectory(TrajetsDirectory);

            Launched = false;
            Account = account;
            PathData = new Dictionary<string, Tuple<MapDirectionEnum, string>>();

            //Account.Network.RegisterPacket<MapComplementaryInformationsDataMessage>(HandleMapComplementaryInformationsDataMessage, MessagePriority.Normal);
            Account.Network.RegisterPacket<InteractiveUseErrorMessage>(
                HandleInteractiveUseErrorMessage, MessagePriority.Normal);
            Account.Network.RegisterPacket<GameMapNoMovementMessage>(
                HandleGameMapNoMovementMessage, MessagePriority.Normal);
        }

        private Dictionary<string, Tuple<MapDirectionEnum, string>> PathData { get; set; }
        private List<int> RessourcesToGather { get; set; }

        public bool Launched { get; set; }

        public IAccount Account { get; set; }

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
            Tuple<MapDirectionEnum, string> tuple;
            try
            {

                tuple = PathData.ContainsKey(Account.Character.Map.Position)
                    ? PathData[Account.Character.Map.Position]
                    : PathData["" + Account.Character.MapId];
                if (tuple != null)
                {
                    switch (tuple.Item2)
                    {
                        case "none":
                            Account.Logger.Log($"[PathManager] Déplacement vers {tuple.Item1}",
                                LogMessageType.Info);
                            mapChangement = Account.Character.Map.ChangeMap(tuple.Item1);
                            break;
                        case "gather":
                            if (Account.Character.GatherManager.CanGatherOnMap(RessourcesToGather))
                            {
                                Account.Logger.Log("Lancement de la récolte");
                                Account.Character.GatherManager.Gather(RessourcesToGather, false);
                                break;
                            }
                            Account.Logger.Log("Rien a récolter - Changement de map ");
                            mapChangement = Account.Character.Map.ChangeMap(tuple.Item1);
                            break;
                        case "fight":
                            Account.Logger.Log("[PathManager] Combat non géré", LogMessageType.Public);
                            mapChangement = Account.Character.Map.ChangeMap(tuple.Item1);
                            break;
                    }
                }
                else
                    Account.Logger.Log($"Map {Account.Character.MapId} non gérée dans le trajet");
            }
            catch (Exception)
            {
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

        private void ParseTrajet(string path)
        {
            PathData = new Dictionary<string, Tuple<MapDirectionEnum, string>>();
            try
            {
                Script script = new Script();
                script.DoFile(path);
                var e = script.Globals.Get("ELEMENTS_TO_GATHER");
                foreach (var s in e.Table.Values)
                {
                    RessourcesToGather.Add((int)s.Number);
                }
                var x = script.Call(script.Globals["move"]);
                foreach (var item in x.Table.Values)
                {
                    var map = item.Table.Get("map");
                    var changeMap = item.Table.Get("changeMap");
                    var door = item.Table.Get("door");
                    var npcBank = item.Table.Get("npcBank");
                    var gather = item.Table.Get("gather");
                    var fight = item.Table.Get("fight");
                    var direction = MapDirectionEnum.South;
                    var action = "none";
                    switch (changeMap.String)
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
                    if (gather.IsNotNil())
                        action = "gather";
                    else if (fight.IsNotNil())
                        action = "fight";
                    PathData.Add(map.String, Tuple.Create(direction, action));
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
