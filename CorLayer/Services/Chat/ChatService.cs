using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorLayer
{
    public class ChatService : BaseService, IChatService
    {
        public ChatService(ChatContext context) : base(context)
        {

        }
    }
}
