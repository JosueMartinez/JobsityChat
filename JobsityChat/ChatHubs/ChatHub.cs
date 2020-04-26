using JobsityChat.Data;
using JobsityChat.Models;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace JobsityChat.ChatHubs
{
    public class ChatHub : Hub
    {
        private IMesssageRepository _messageRepository;

        public ChatHub(IMesssageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task SendMessage(string username, string message)
        {
            var msgTime = DateTime.Now.ToString("h:mm:ss tt");

            if (message.Contains("/stock="))
            {
                //send original message to all clients js function
                await Clients.All.SendAsync("ReceiveMessage", username, message, msgTime);

                //get stock message
                var stockRequest = message.Split('=');
                var stockCode = stockRequest[1];
                username = "StockBot";
                message = StockBot.BotTasks.GetStockMessage(stockCode);
            }
            else
            {
                var entity = new Message
                {
                    Content = message,
                    User = username,
                    TimeStamp = DateTime.Now
                };

                _messageRepository.Add(entity);
            }
            
            //send message to all clients js function
            await Clients.All.SendAsync("ReceiveMessage", username, message, msgTime);
        }
    }
}
