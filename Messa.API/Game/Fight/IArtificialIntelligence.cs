using Messa.API.Core;

namespace Messa.API.Game.Fight
{
    public interface IArtificialIntelligence
    {
        /// <summary>
        ///     Charge l'IA
        /// </summary>
        void Load(IAccount account, string path);
    }
}