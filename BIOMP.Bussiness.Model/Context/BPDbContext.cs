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
            //����ʱ����������ݿ�ʹ���ṹ��ͬ��
            new CreateDatabaseIfNotExists<BPDbContext>();//Ĭ��  �����ھʹ���
        }
    }
}
