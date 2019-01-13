using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public partial interface IOrdersManage:ICommonManage<Orders>, IDependency
    {
        IQueryable<Orders> GetOrderByUserService(Users user);
    }
}
