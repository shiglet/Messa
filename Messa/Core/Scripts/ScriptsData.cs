using MoonSharp.Interpreter;

namespace Messa.Core.Scripts
{
    [MoonSharpUserData]
    public class ScriptCharacter
    {
        public int LifePointsPercentage { get; set; }
    }

    [MoonSharpUserData]
    internal class ScriptEnemy
    {
        public int LifePointsPercentage { get; set; }
    }
}