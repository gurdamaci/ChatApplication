using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Entities.Concrete;

namespace ChatApp.DAL.Abstract
{
    public interface IChatRoomDal
    {
        List<ChatRoom> getAll();
    }
}
