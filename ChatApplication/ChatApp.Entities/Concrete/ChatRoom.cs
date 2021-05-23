using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatApp.Entities.Abstract;

namespace ChatApp.Entities.Concrete
{
    public class ChatRoom: IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
