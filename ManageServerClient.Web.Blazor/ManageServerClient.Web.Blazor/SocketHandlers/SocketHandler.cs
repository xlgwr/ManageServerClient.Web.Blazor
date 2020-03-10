using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;

namespace ManageServerClient.Web.Blazor.SocketHandlers
{
    public class SocketHandler
    {
        public const int BufferSize = 1024 * 4;
        WebSocket webSocket;
        SocketHandler(WebSocket socket)
        {

            this.webSocket = socket;
        }
        public async Task EchoLoop()
        {
            var buffer = new byte[BufferSize];
            var seg = new ArraySegment<byte>(buffer);
            while (this.webSocket.State == WebSocketState.Open)
            {
                var incoming = await this.webSocket.ReceiveAsync(seg, CancellationToken.None);
                var outgoing = new ArraySegment<byte>(buffer, 0, incoming.Count);
                await this.webSocket.SendAsync(outgoing, WebSocketMessageType.Text, true, CancellationToken.None);
            }
        }
        public async Task Echo()
        {
            var buffer = new byte[BufferSize];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (!result.CloseStatus.HasValue)
            {
                await webSocket.SendAsync(new ArraySegment<byte>(buffer, 0, result.Count), result.MessageType, result.EndOfMessage, CancellationToken.None);

                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
        }
        public static async Task Acceptor(HttpContext context, Func<Task> next)
        {
            if (context.Request.PathBase.Value != "/ws")
            {
                await next();
            }
            if (!context.WebSockets.IsWebSocketRequest)
            {
                context.Response.StatusCode = 400;
            }
            else
            {
                WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                var socketHandler = new SocketHandler(webSocket);
                await socketHandler.Echo();
                //await socketHandler.EchoLoop(); 
            }

        }
        /// <summary>
        /// 路由绑定处理
        /// //绑定websocket
        /// app.Map("/ws", SocketHandler.Map);
        /// </summary>
        /// <param name="app"></param>
        public static void Map(IApplicationBuilder app)
        {
            var webSocketOptions = new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromSeconds(120),
                ReceiveBufferSize = 4 * 1024
            };
            //webSocketOptions.AllowedOrigins.Add("https://client.com");
            //webSocketOptions.AllowedOrigins.Add("https://www.client.com");

            app.UseWebSockets(webSocketOptions);

            app.Use(SocketHandler.Acceptor);

            //app.Use(async (context, next) => {
            //    var socket = await context.WebSockets.AcceptWebSocketAsync();
            //    var socketFinishedTcs = new TaskCompletionSource<object>();

            //    BackgroundSocketProcessor.AddSocket(socket, socketFinishedTcs);

            //    await socketFinishedTcs.Task;
            //}); 
        }

    }
}
