using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Chat : BaseEntity
    {
        public string ChatBody { get; set; }

        public long UserId { get; set; }
        public long ChatGroupId { get; set; }



        #region Relation
        [ForeignKey("UserId")]
        public User User { get; set; }

        [ForeignKey("ChatGroupId")]
        public Group ChatGroup { get; set; }

        #endregion
    }
}
