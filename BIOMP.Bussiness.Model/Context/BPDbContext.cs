namespace BIOMP.EF.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BPDbContext : DbContext
    {
        public BPDbContext()
            : base("name=BPDbContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<User1> User1s { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //启动时可以完成数据库和代码结构的同步
            new CreateDatabaseIfNotExists<BPDbContext>();//默认  不存在就创建
        }
    }
}
