using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Entities.Concrete;

namespace ChatApp.DAL.Abstract
{
    public interface IUserDal
    {
        
        void AddUser(User user);
        void UpdateUser(User user);
    }
}
