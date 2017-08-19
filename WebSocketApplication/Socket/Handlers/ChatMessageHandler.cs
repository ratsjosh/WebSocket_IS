using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using WebSocketApplication.Models;

namespace WebSocketApplication.Socket.Handlers
{
    public class ChatMessageHandler : WebSocketHandler
    {
        public ChatMessageHandler(WebSocketConnectionManager webSocketConnectionManager) : base(webSocketConnectionManager)
        {
        }

        public override async Task OnConnected(WebSocket socket)
        {
            await base.OnConnected(socket);

            var connections = JsonConvert.SerializeObject(new SendMessageViewModel
            {
                Sender = WebSocketConnectionManager.GetId(socket),
                Message = JsonConvert.SerializeObject(WebSocketConnectionManager.GetAll().Select(x => x.Key).ToList()),
                IsPrivateMessage = false
            });

            await SendMessageToAllAsync(connections);
        }

        public override async Task ReceiveAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer)
        {
            var socketId = WebSocketConnectionManager.GetId(socket);
            var message = $"{socketId} said: {Encoding.UTF8.GetString(buffer, 0, result.Count)}";

            await SendMessageToAllAsync(message);
        }

        public override async Task ReceiveWithAccountInformationAsync(WebSocket socket, WebSocketReceiveResult result, byte[] buffer, ReceiveMessageViewModel receiveMessage)
        {
            var receiver = WebSocketConnectionManager.GetSocketById(receiveMessage.Receiver);

            if (receiver != null)
            {
                var socketId = WebSocketConnectionManager.GetId(socket);
                var sendMessage = JsonConvert.SerializeObject(new SendMessageViewModel
                {
                    Sender = socketId,
                    Message = receiveMessage.Message
                });

                await SendMessageAsync(receiveMessage.Receiver, sendMessage);
            }
            else
            {
                await SendMessageAsync(receiveMessage.Receiver, "Can not seed to " + receiveMessage.Receiver);
            }
        }
    }
}
