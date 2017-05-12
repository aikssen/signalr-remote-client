using System;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace SignalRChat
{
    //[Authorize]
    public class ChatHub : Hub
    {
        public string UserName { get; set; }
        public string Message { get; set; }

        public void Send(string who, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(new ChatHub() { UserName = who, Message = message });
            //Clients.Caller.receiveToken(who, System.Guid.NewGuid());
        }


        public override Task OnConnected()
        {
            Clients.Caller.receiveToken(System.Guid.NewGuid());
            return base.OnConnected();
        }
    }
}