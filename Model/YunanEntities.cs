using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace Model
{
    public class YunanEntities:DbContext
    {
        //连接字符串
        public YunanEntities():base("name=YunanEntities")
        {

        }
        static YunanEntities()
        {
            //初始数据库植入种子
            Database.SetInitializer<YunanEntities>(new SeedingDataInitializer() );
        }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Talks> Talks { get; set; }
        public virtual DbSet<Scenic> Scenic { get; set; }
        public virtual DbSet<ScenicDetails> ScenicDetails { get; set; }
        public virtual DbSet<Orders> Order { get; set; } 
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<AdminScenic> Admin_Scenic { get; set; }
        public virtual DbSet<NewsDetalis> NewsDetalis { get; set; }
        public virtual DbSet<VoteLog> VoteLog { get; set; }
        public virtual DbSet<NewsCollect> NewsCollect { get; set; }

        //级联删除定义
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //外键的定义，定义有些重复
            modelBuilder.Entity<Scenic>().HasKey(s => s.ScenicId);
            modelBuilder.Entity<Scenic>().HasMany(s => s.OrderDetail).WithRequired(s=>s.Scenic).HasForeignKey(s => s.ScenicId);
            modelBuilder.Entity<Scenic>().HasMany(s => s.ScenicDetail).WithRequired(s => s.Scenic).HasForeignKey(s => s.ScenicId);
            modelBuilder.Entity<Scenic>().HasMany(s => s.AdminScenic).WithRequired(s => s.Scenic).HasForeignKey(s => s.ScenicId);

            //有待更改级联的关系，用户删除订单，订单详情也会删除
            modelBuilder.Entity<Users>().HasMany(u => u.Order).WithRequired(u => u.user).HasForeignKey(u => u.UserId).WillCascadeOnDelete(false);
            modelBuilder.Entity<Users>().HasMany(u => u.Talk).WithRequired(u => u.user).HasForeignKey(u => u.UserId).WillCascadeOnDelete(false);
            modelBuilder.Entity<News>().HasMany(n => n.NewsDetails).WithRequired(n => n.news).HasForeignKey(n => n.NewsId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Orders>().HasMany(o=>o.orderDetail).WithRequired(o=>o.Order).HasForeignKey(o=>o.OrderId).WillCascadeOnDelete(true);
            base.OnModelCreating(modelBuilder);
        }

    }

    //数据库种子的初始化 CreateDatabaseIfNotExists(防止数据迁移时数据库数据被删除)
    public class SeedingDataInitializer :CreateDatabaseIfNotExists<YunanEntities>
    {
        protected override void Seed(YunanEntities context)
        {
            //var User = new Users()
            //{
            //    UserId=0,
            //    UserName = "乔木志",
            //    UserPassward = "931798",
            //    UserTel = 18788888888,
            //    Birthday = DateTime.Now,
            //    UserAddress = "江西省赣州市",
            //    UserHeadimg = "",
            //    Usermotto = "xxx",
            //    IdCard="360732888888888888"
            //};
            //context.Users.Add(User);
            var Scenic = new Scenic()
            {
                ScenicId = 1,
                ScenicTitle = "大理古城",
                City = "DALLY",
                type = "古城",
                ScenicContent = "xxxxxx",
                ScenicVote = 0,
                ScenicStyle = "亲子",
                ScenicPrice = 860,
                Days = 6,
                ScenicCoverImg = "xxxx",
                ScenicKeyWord = "大理",
            };
            context.Scenic.Add(Scenic);

            base.Seed(context);
        }
    }
}
