using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Business.Abstract;
using ChatApp.DAL.Abstract;
using ChatApp.DAL.Concrete.ADONET;
using ChatApp.Entities.Concrete;

namespace ChatApp.Business.Concrete
{
    public class ChatRoomManager : IChatRoomService
    {
        private readonly IChatRoomDal _chatRoomDal;

        //TODO: Code Refactor: IOC Container ile IUserDal yapılandırmasını yapıp parametresiz CTOR' u devre dışı bırakmak gerekiyor.
        public ChatRoomManager(IChatRoomDal chatRoomDal)
        {
            _chatRoomDal = chatRoomDal;
        }

        public List<ChatRoom> getAll()
        {
            return _chatRoomDal.getAll();
        }
    }
}
