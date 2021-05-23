using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Core.MessageQueuing
{
    public interface IMQAdapter
    {
        void SendMessage(Object obj, string queueuName);
    }
}
