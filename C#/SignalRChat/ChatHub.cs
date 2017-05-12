using System;
using System.Web;
using Microsoft.AspNet.SignalR;
namespace SignalRChat
{
    public class ChatHub : Hub
    {
        public string UserName { get; set; }
        public string Message { get; set; }

        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(new ChatHub() { UserName = name, Message = message });
            //Clients.ToString();
        }
    }
}