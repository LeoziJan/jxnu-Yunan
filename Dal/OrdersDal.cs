using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Idal;
using System.Data.Entity;
using Model;

namespace Dal
{
    public class OrdersDal : CommonDal<Orders>, IOrdersDal
    {
        private DbContext db = DbEntity.Setdb();
        public IQueryable<Orders> GetOrderByUser(Users user)
        {
            var order = from o in db.Set<Orders>()
                        where o.UserId == user.UserId
                        select o;
            return order;
        }
    }
}
