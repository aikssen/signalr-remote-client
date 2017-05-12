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
            //string token = 'TOKEN';
            Clients.Caller.receiveToken(who, "TOKEN");
        }


        //public void Send(string who, string message)
        //{
        //    // Call the broadcastMessage method to update clients.
        //    //Clients.All.broadcastMessage(new ChatHub() { UserName = who, Message = message });
        //    //Clients.User(userId).send(message);

        //    //string name = Context.User.Identity.Name;
        //    string name = Context.User

        //    //Clients.Group(who).broadcastMessage(new ChatHub() { UserName = name, Message = message });
        //    Clients.All.broadcastMessage(new ChatHub() { UserName = name, Message = Context.ConnectionId });
        //    //Clients.All.broadcastMessage(Context);
        //}

        //public override Task OnConnected()
        //{
        //    string name = Context.User.Identity.Name;

        //    Groups.Add(Context.ConnectionId, name);

        //    return base.OnConnected();
        //}
    }
}