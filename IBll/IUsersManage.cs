using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Autofac;

namespace IBLL
{
    public partial interface IUsersManage:ICommonManage<Users>,IDependency
    {
        //
    }
}
