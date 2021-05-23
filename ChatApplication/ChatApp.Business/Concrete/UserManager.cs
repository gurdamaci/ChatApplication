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
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        //TODO: Code Refactor: IOC Container ile IUserDal yapılandırmasını yapıp parametresiz CTOR' u devre dışı bırakmak gerekiyor.
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        
        public UserManager()
        {
            _userDal = new AdoUserDal();
        }

        public void AddUser(User user)
        {
            _userDal.AddUser(user);
        }
    }
}
