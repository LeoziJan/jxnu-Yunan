using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;
using System.Linq.Expressions;

namespace IBLL
{
    public partial interface ITalksManage:ICommonManage<Talks>, IDependency
    {
        IQueryable<Talks> UserTalksService(Users user);

        IQueryable<Talks> NewsTalksService(News news);

        int NewsTalksCount(News news);
    }
}
