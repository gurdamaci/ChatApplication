using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChatApp.ASPNETWinFormUI.RabbitMQ;
using ChatApp.Core.MessageQueuing;
using ChatApp.Entities.Concrete;
using Microsoft.AspNet.SignalR;

namespace ChatApp.ASPNETWinFormUI.Scripts
{
    public class ChatHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            //Groups.Add(Context.ConnectionId, "SohbetOdası");
            //Clients.Group("SohbetOdası").addChatMessage("Message");
            Clients.All.broadcastMessage(name, message);
           
            
            Message message2 = new Message
            {
                ChatRoomID = 1,
                MessageText = message,
                UserID = 2
            };
            
            RabbitMQPublisher.SendMessage(message2, "MessageLog");
        }
    }
}