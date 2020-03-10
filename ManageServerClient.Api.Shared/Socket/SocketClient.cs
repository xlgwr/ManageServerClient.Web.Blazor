using Fleck;
using ManageServerClient.Shared.Common;
using SuperSocket.ClientEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocket4Net;

namespace ManageServerClient.Api.Shared.Socket
{
    public class SocketClient
    {
        private static SocketClient _socketClient = new SocketClient();
        private WebSocket websocket = null;

        public static SocketClient GetInstance()
        {
            return _socketClient;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipString">ip地址</param>
        /// <param name="port">端口</param>
        public void InitWebSocket(string ipString, int port)
        {
            websocket = new WebSocket($"ws://{ipString}:{port}"); 
            websocket.Opened += new EventHandler(websocket_Opened);
            websocket.Error += new EventHandler<ErrorEventArgs>(websocket_Error);
            websocket.Closed += new EventHandler(websocket_Closed);
            websocket.MessageReceived += new EventHandler<MessageReceivedEventArgs>(websocket_MessageReceived);
            websocket.Open();
        }

        public IEnumerable<string> SupportedSubProtocols { get; set; }
        List<IWebSocketConnection> allSockets = new List<IWebSocketConnection>();

        private void InitWebSocketServer()
        {
            FleckLog.Level = LogLevel.Debug;
            var server = new WebSocketServer("ws://0.0.0.0:9001");
            server.RestartAfterListenError = true;
            server.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    allSockets.Add(socket);
                };
                socket.OnClose = () =>
                {
                    allSockets.Remove(socket);
                };
                socket.OnMessage = message =>
                {
                    EventHelper.OnRecvEvent(message);
                };
            });
        }

        #region webSocket事件
        /// <summary>
        /// client接收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void websocket_MessageReceived(object sender, EventArgs e)
        {
            if (e is MessageReceivedEventArgs)
            {
                EventHelper.OnRecvEvent(((MessageReceivedEventArgs)e).Message);
            }
        }

        /// <summary>
        /// client 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void websocket_Closed(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// client打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void websocket_Opened(object sender, EventArgs e)
        {
           // websocket.Send("Hello server!");
        }

        /// <summary>
        /// client 接收错误信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void websocket_Error(object sender, ErrorEventArgs e)
        {
            EventHelper.OnRecvEvent(e.Exception.ToString());
        }
        #endregion

        public void Send(string message)
        {
            if (websocket != null && websocket.State == WebSocketState.Open)
            {
                websocket.Send(message);
            }
        }
    }
}
