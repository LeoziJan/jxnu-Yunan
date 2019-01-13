using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Idal
{
    public partial interface IOrderDetailDal:ICommonDal<OrderDetails>
    {
        IQueryable<OrderDetails> GetODetailByOrder(Orders order);

        IQueryable<OrderDetails> GetODetailByUser(Users user);

        //过期完成订单的查询
    }
}
