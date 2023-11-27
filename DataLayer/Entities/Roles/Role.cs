using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Role : BaseEntity
    {
        [MaxLength(50)]
        public string Title { get; set; }
    }
}
