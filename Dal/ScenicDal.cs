using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Idal;
using Model;
using System.Data.Entity;
using System.Linq.Expressions;


namespace Dal
{
    public partial class ScenicDal : CommonDal<Scenic>, IScenicDal
    {
        private DbContext db = DbEntity.Setdb();
        private YunanEntities ye = new YunanEntities();

        public IQueryable<Scenic> FindTopSales()
        {
            
            var scenic = (from s in db.Set<Scenic>()
                          where (
                          from a in db.Set<Scenic>()
                          join c in db.Set<OrderDetails>() on a.ScenicId equals c.ScenicId
                          group a by a.ScenicId into g
                          orderby g.Count() descending
                          select g.Key
                          ).Contains(s.ScenicId)
                          select s).Take(4);
            return scenic;

            //var scenic = from s in db.Set<Scenic>()
            //             where
            //             (
            //             from c in db.Set<Scenic>()
            //             join o in db.Set<OrderDetails>() on s.ScenicId equals o.ScenicId
            //             select new { scenicid = c.ScenicId }).GroupBy(b => b.scenicid).OrderBy(b => b.Count()).Select(b => b.Key).Contains(s.ScenicId)
            //             select s;
            //return scenic;
        }

        /// <summary>
        /// 按关键字来筛选景区
        /// </summary>
        /// <param name="keyword">景区关键字</param>
        /// <returns></returns>
        public IQueryable<Scenic> GetSceicByKeyWord(string keyword)
        {
            var scenic = from s in db.Set<Scenic>()
                         join d in db.Set<ScenicDetails>() on s.ScenicId equals d.ScenicId
                         where s.ScenicKeyWord.Contains(keyword) || s.ScenicTitle.Contains(keyword) || d.ScenicName.Contains(keyword)
                         select s;
            return scenic;
        }

        public Scenic GetScenicByOrder(Orders order)
        {
            Scenic scenic =( from s in db.Set<Scenic>()
                         join o in db.Set<OrderDetails>() on s.ScenicId equals o.ScenicId
                         join d in db.Set<Orders>() on o.OrderId equals d.OrderId
                         where d.OrderId == order.OrderId
                         select s).FirstOrDefault();

            return scenic;
        }

        //价格排序是景区和景区分类子类来的，
        //所以考虑用构造函数，重载，或扩展方法三种方式之一。
        /// <summary>
        /// 
        /// </summary>
        /// <param name="asc">是否降序</param>
        /// <returns></returns>
        public IQueryable<Scenic> GetScenicByPrice(bool asc)
        {
            if (asc)
            {
                var scenic = (from s in db.Set<Scenic>()
                              orderby s.ScenicPrice descending
                              select s);
                return scenic;
            }
            else
            {
                var scenic = (from s in db.Set<Scenic>()
                              orderby s.ScenicPrice ascending
                              select s);
                return scenic;
            }          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="style">旅行方式</param>
        /// <returns></returns>
        public IQueryable<Scenic> GetScenicByStyle(string style)
        {
            var scenic = from s in db.Set<Scenic>()
                         where s.ScenicStyle == style
                         select s;
            return scenic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type">景区类型</param>
        /// <returns></returns>
        public IQueryable<Scenic> GetScenicByType(string type)
        {
            var scenic = from s in db.Set<Scenic>()
                         where s.type==type
                         select s;
            return scenic;
        }

        public Scenic GetScenicById(int id)
        {
            return db.Set<Scenic>().Where(s => s.ScenicId == id).FirstOrDefault();
        }

        public int count(int id)
        {
            var count = (from o in db.Set<OrderDetails>()
                         where o.ScenicId == id
                         select o).Count();
            return count;
        }

        public IList<Scenic> GetScenic()
        {
            return ye.Scenic.ToList();
        }

        /// <summary>
        /// 插入一个活动
        /// </summary>
        /// <param name="sc"></param>
        /// <returns></returns>
        public bool InsertScenic(Scenic sc)
        {
            ye.Scenic.Add(sc);
            return ye.SaveChanges() > 0;
        }
    }
}
