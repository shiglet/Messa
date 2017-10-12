using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messa.API.Core;
using Messa.API.Messages;
using Messa.API.Network;
using Messa.API.Protocol;
using Messa.API.Utils.Enums;

namespace Messa.FullSocket
{
    public class NetworkMessageDispatcher : MessageDispatcher
    {
        public IClient Server { get; set; }

        protected override void Dispatch(Message message, object token)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            if (message is NetworkMessage nMessage)
                Dispatch(nMessage, token);
            else
                base.Dispatch(message, token);
        }

        protected void Dispatch(NetworkMessage message, object token)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            if (message.Destinations.HasFlag(ListenerEntry.Local))
                try
                {
                    InternalDispatch(message, token);
                }
                catch (Exception ex)
                {
                    (token as IAccount)?.Logger.Log($@"Cannot dispatch {message}",LogMessageType.Error);
                    (token as IAccount)?.Logger.Log(ex.Message,LogMessageType.Error);
                }

            if (Server != null && message.Destinations.HasFlag(ListenerEntry.Server))
                Server.Send(message);

            message.OnDispatched();
            OnMessageDispatched(message);
        }

        private void InternalDispatch(NetworkMessage message, object token)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));
            var handlers =
                GetHandlers(message.GetType(), token)
                    .ToArray(); // have to transform it into a collection if we want to add/remove handler


            foreach (var handler in handlers)
            {
                handler.Handler((IAccount)token, message);

                if (message.Canceled)
                    break;
            }
        }
    }
}
