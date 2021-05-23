using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ChatApp.Entities.Concrete;
using Microsoft.AspNet.SignalR;

namespace ChatApp.ASPNETWinFormUI
{
    public partial class ChatRooms : System.Web.UI.Page
    {

        static private Dictionary<string, string> ChatList = new Dictionary<string, string>();
         protected void Page_Load(object sender, EventArgs e)
         {
             string roomName = Request.QueryString["Room"];
         }
    }
    //public class Chat : Hub
    //{
    //    public async override Task OnConnected()
    //    {
    //        await Clients.Caller.connected(Context.ConnectionId);
    //    }

    //    public async Task SendMessageToAll(string Message, string UserName)
    //    {
    //        await Clients.All.SendMessageAll(Message, UserName);
    //    }
    //}

}