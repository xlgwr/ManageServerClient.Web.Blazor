using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageServerClient.Shared.Common
{
    public class EventHelper
    {
        public delegate void OnRecvEventHandler(string message);
        private static event OnRecvEventHandler RecvEvent;
        public static void RegRecvEvent(OnRecvEventHandler onRecvEventHandler)
        {
            if (onRecvEventHandler != null)
            {
                RecvEvent += onRecvEventHandler;
            }
        }

        public static void OnRecvEvent(string message)
        {
            RecvEvent?.Invoke(message);
        }
    }
}
