using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;
using Idal;


namespace Dal
{
    public class OrderDetailDal : CommonDal<OrderDetails>, IOrderDetailDal
    {
        private DbContext db = DbEntity.Setdb();
        public IQueryable<OrderDetails> GetODetailByOrder(Orders order)
        {
            var orderdetail = (from o in db.Set<OrderDetails>()
                               join u in db.Set<Users>() on o.UserId equals u.UserId
                               where o.OrderId == order.OrderId & u.UserId == order.UserId
                               select o);
            return orderdetail;
        }

        //待开发
        public IQueryable<OrderDetails> GetODetailByUser(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
