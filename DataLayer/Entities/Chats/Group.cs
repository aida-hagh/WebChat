using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Group : BaseEntity
    {
        [MaxLength(100)]
        public string GroupTitle { get; set; }
        [MaxLength(110)]
        public string GroupToken { get; set; }
        [MaxLength(110)]
        public string ImageName { get; set; }

        public long OwnerId { get; set; }



        #region Relation

        [ForeignKey(nameof(OwnerId))]
        public User User { get; set; }  
        public ICollection<Chat> Chats { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; }

        #endregion
    }
}
