using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Idal
{
    //扩展接口icommondal
    public partial interface IUsersDal:ICommonDal<Users>
    {
        //查看用户自己写的攻略

        //查看用户的订单
    }
}
