using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChatApp.ASPNETWinFormUI.RabbitMQ;
using ChatApp.Business.Abstract;
using ChatApp.Business.Concrete;
using ChatApp.DAL.Concrete.ADONET;
using ChatApp.Entities.Concrete;


namespace ChatApp.ASPNETWinFormUI
{
    public partial class Test : System.Web.UI.Page
    {
 
        public IUserService _userService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Entities.Concrete.User user = new Entities.Concrete.User
            {
                Mail = "TestEmail@Test.Com.tr",
                Name = "Adil",
                SurName = "Kudu"
            };
            Message message = new Message
            {
                ChatRoomID = 1,
                MessageText = "TEXTT",
                UserID = 2
            };
            RabbitMQPublisher.SendMessage(message, "MessageLog");

            //_mqAdapter.SendMessage(message,"MessageLog");
            //this._mqAdapter.SendMessage(message,"MessageLog");
            this._userService.AddUser(user);
        }
    }
}