using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using IBLL;
using Dal;
using Model;

namespace bll
{
    public partial class UsersManage:CommonManage<Users>,IUsersManage
    {
        //
    }
}
