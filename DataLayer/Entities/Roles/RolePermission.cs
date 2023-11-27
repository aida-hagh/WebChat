using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class RolePermission : BaseEntity
    {
        public long RoleId { get; set; }

        public Permission Permission { get; set; }

        #region Relation

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        #endregion
    }
}
