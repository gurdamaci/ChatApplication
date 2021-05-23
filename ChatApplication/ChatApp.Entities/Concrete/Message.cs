using System;
using ChatApp.Entities.Abstract;

namespace ChatApp.Entities.Concrete
{
    public class Message : IEntity
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ChatRoomID { get; set; }
        public string MessageText { get; set; }
        public DateTime Date { get; set; }
    }
}