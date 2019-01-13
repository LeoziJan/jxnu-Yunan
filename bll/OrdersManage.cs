using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;
using IBLL;

namespace bll
{
    public partial class OrdersManage : CommonManage<Orders>, IOrdersManage
    {
        private OrdersDal od = new OrdersDal();
        /// <summary>
        /// 查询用户的所有订单
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        public IQueryable<Orders> GetOrderByUserService(Users user)
        {
            return od.GetOrderByUser(user);
        }
    }
}
