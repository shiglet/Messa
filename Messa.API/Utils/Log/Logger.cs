using Messa.API.Utils.Enums;

namespace Messa.API.Utils.Log
{
    public class Logger
    {
        public delegate void OnLogDelegate(string log);
        public event OnLogDelegate OnLog;

        public void Log(string log, LogMessageType entry = LogMessageType.Info)
        {
            OnLog?.Invoke(log);
        }
    }
}
