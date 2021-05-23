using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.DAL.Abstract;
using ChatApp.Entities.Concrete;

namespace ChatApp.DAL.Concrete.ADONET
{
    public class AdoChatRoomDal : IChatRoomDal
    {
        #region Veritabanı Bağlantı
        private AdoNetContext veritabani;

        public AdoChatRoomDal()
        {
            veritabani = AdoNetContext.Olustur();
        }
 
        #endregion
        
        public List<ChatRoom> getAll()
        {
            try
            {
                List<ChatRoom> chatRooms = new List<ChatRoom>();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from CHATROOMS", veritabani.BaglantiMetini);
                DataTable tmpchatRooms = new DataTable();
                adapter.Fill(tmpchatRooms);

                for (int i = 0; i < tmpchatRooms.Rows.Count; i++)
                {
                    ChatRoom room = new ChatRoom();
                    room.ID = Convert.ToInt32(tmpchatRooms.Rows[i]["ID"].ToString());
                    room.Name = tmpchatRooms.Rows[i]["NAME"].ToString();
                    chatRooms.Add(room);
                } 
                return chatRooms;
            }
            catch (Exception ex)
            {
                veritabani.BaglantiKes();
                throw new ArgumentException("VK:ChatRooms Getirmede Hata.Orjinal Hata Mesajı:" + ex.Message);
            }
        }
    }
}
