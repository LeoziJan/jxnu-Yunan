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
    public partial class OrderDetailManage : CommonManage<OrderDetails>, IOrderDetailManage
    {
        private OrderDetailDal odd = new OrderDetailDal();

        /// <summary>
        /// 查询订单包含的订单详情
        /// </summary>
        /// <param name="order">订单</param>
        /// <returns></returns>
        public IQueryable<OrderDetails> GetODByOrderService(Orders order)
        {
            return odd.GetODetailByOrder(order);
        }

        /// <summary>
        /// 查询用户的订单详情
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        public IQueryable<OrderDetails> GetODByUserService(Users user)
        {
            return odd.GetODetailByUser(user);
        }
    }
}
