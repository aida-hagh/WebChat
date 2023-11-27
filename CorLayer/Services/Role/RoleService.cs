using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorLayer
{
    public class RoleService : BaseService, IRoleService
    {
        public RoleService(ChatContext context) : base(context)
        {
        }
    }
}
