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
            await Clients.All.SendAsync("ReceiveMessage", username, message, msgTime);
        }
    }
}
