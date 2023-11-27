using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserGroup : BaseEntity
    {
        public long UserId { get; set; }
        public long GroupId { get; set; }


        #region Relation

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(GroupId))]
        public Group Group { get; set; }

        #endregion
    }
}
