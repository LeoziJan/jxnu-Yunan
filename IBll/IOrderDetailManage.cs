using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public partial interface IOrderDetailManage:ICommonManage<OrderDetails>, IDependency
    {
        IQueryable<OrderDetails> GetODByOrderService(Orders order);

        IQueryable<OrderDetails> GetODByUserService(Users user);

        //过期完成订单的查询
    }
}
