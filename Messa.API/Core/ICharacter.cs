﻿using System.Collections.Generic;
using Messa.API.Core.Pathmanager;
using Messa.API.Game.Achievement;
using Messa.API.Game.Alliance;
using Messa.API.Game.Bank;
using Messa.API.Game.BidHouse;
using Messa.API.Game.Chat;
using Messa.API.Game.Fight;
using Messa.API.Game.Friend;
using Messa.API.Game.Guild;
using Messa.API.Game.Inventory;
using Messa.API.Game.Jobs;
using Messa.API.Game.Map;
using Messa.API.Game.Party;
using Messa.API.Protocol.Enums;
using Messa.API.Protocol.Network.Types.Game.Character.Characteristic;
using Messa.API.Protocol.Network.Types.Game.Character.Restriction;
using Messa.API.Protocol.Network.Types.Game.Context.Roleplay.Job;
using Messa.API.Protocol.Network.Types.Game.Data.Items;
using Messa.API.Protocol.Network.Types.Game.Look;
using Messa.API.Utils.Enums;

namespace Messa.API.Core
{
    public interface ICharacter
    {
        /// <summary>
        ///     The actual status of the character
        /// </summary>
        CharacterStatus Status { get; set; }

        /// <summary>
        ///     Determine if this is his first connection or not
        /// </summary>
        bool IsFirstConnection { get; set; }

        /// <summary>
        ///     The character id
        /// </summary>
        double Id { get; set; }

        /// <summary>
        ///     The character name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        ///     The character level
        /// </summary>
        int Level { get; set; }

        /// <summary>
        ///     The character gender
        /// </summary>
        bool Sex { get; set; }

        /// <summary>
        ///     The character Stats (include Kamas, etc)
        /// </summary>
        CharacterCharacteristicsInformations Stats { get; set; }

        /// <summary>
        ///     The character Look
        /// </summary>
        EntityLook Look { get; set; }

        /// <summary>
        ///     The character Breed
        /// </summary>
        BreedEnum Breed { get; set; }

        /// <summary>
        ///     The character life percentage
        /// </summary>
        int LifePercentage { get; }

        /// <summary>
        ///     The character weight percentage
        /// </summary>
        int WeightPercentage { get; }

        /// <summary>
        ///     The character energy percentage
        /// </summary>
        int EnergyPercentage { get; }

        /// <summary>
        ///     The character Experience percentage
        /// </summary>
        int ExperiencePercentage { get; }

        /// <summary>
        ///     The character actual cellid on the map
        /// </summary>
        int CellId { get; set; }

        /// <summary>
        ///     The character actual map id
        /// </summary>
        int MapId { get; set; }

        /// <summary>
        ///     The current weight of the character
        /// </summary>
        uint Weight { get; set; }

        /// <summary>
        ///     The maximum weight of the character
        /// </summary>
        uint MaxWeight { get; set; }

        /// <summary>
        ///     All character restrictions
        /// </summary>
        ActorRestrictionsInformations Restrictions { get; set; }

        /// <summary>
        ///     The character spells
        /// </summary>
        List<SpellItem> Spells { get; set; }

        /// <summary>
        ///     The character jobs
        /// </summary>
        List<JobExperience> Jobs { get; set; }

        /// <summary>
        ///     Gather Manager
        /// </summary>
        IGatherManager GatherManager { get; set; }

        IPathManager PathManager { get; set; }

        IAchievement Achievement { get; set; }

        IAlliance Alliance { get; set; }

        IBidHouse BidHouse { get; set; }

        IChat Chat { get; set; }
        IBank Bank { get; set; }

        IMap Map { get; set; }

        IFight Fight { get; }

        IFriend Friend { get; set; }

        IGuild Guild { get; set; }

        IInventory Inventory { get; set; }

        IParty Party { get; set; }

        /// <summary>
        ///     This method return the url string of the image of this character
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="orientation"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="zoom"></param>
        /// <returns></returns>
        string GetSkinUrl(string mode, int orientation, int width, int height, int zoom);
    }
}