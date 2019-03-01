using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIOMP.EF.Model
{
    [Table("User1")]
    public partial class User1
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime CreateTime { get; set; }

        public int CreatorId { get; set; }

        public bool IsEnable { get; set; }

        public string Mark { get; set; }

        public string TestDB { get; set; }
    }
}
