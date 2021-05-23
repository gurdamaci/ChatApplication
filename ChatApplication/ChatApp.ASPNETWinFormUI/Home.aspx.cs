using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ChatApp.Business.Abstract;
using ChatApp.Entities.Concrete;

namespace ChatApp.ASPNETWinFormUI
{
    public partial class Home : System.Web.UI.Page
    {
        public IChatRoomService _chatRoomService { get; set; }
        public Home()
        {
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //List<ChatRoom> testList = new List<ChatRoom>();
            //ChatRoom m1       = new ChatRoom();
            //m1.ID= 1;
            //m1.Name = "Test ODA 1";

            //ChatRoom m2 = new ChatRoom();
            //m2.ID = 2;
            //m2.Name = "Test ODA 2";

            //testList.Add(m1);
            //testList.Add(m2);

            List<ChatRoom> chatRoomList = new List<ChatRoom>(); 
              chatRoomList  = _chatRoomService.getAll();

            rptRoles.DataSource = chatRoomList;
            rptRoles.DataBind();
        }


    }
}