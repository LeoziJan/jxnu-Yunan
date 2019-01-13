using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Idal
{
    public partial interface INewsDal:ICommonDal<News>
    {
        IQueryable<News> GetNewsByTime();
        IQueryable<News> GetNewsByUser(string name);

        //查询点赞数最多的攻略
        IQueryable<News> FindTopVote();
    }
}
