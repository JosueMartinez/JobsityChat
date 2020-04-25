using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace JobsityChat.ChatHubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string username, string message)
        {
            var msgTime = DateTime.Now.ToString("h:mm:ss tt");
            //send message to all clients js function
            await Clients.All.SendAsync("ReceiveMessage", username, message, msgTime);
        }
    }
}
