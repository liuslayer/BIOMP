namespace BIOMP.EF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime CreateTime { get; set; }

        public int CreatorId { get; set; }

        public bool IsEnable { get; set; }

        public string Mark { get; set; }

        //public string TestDB { get; set; }
    }
}
