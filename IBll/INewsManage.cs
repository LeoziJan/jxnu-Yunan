using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public partial interface INewsManage:ICommonManage<News>, IDependency
    {
        IQueryable<News> GetNewsByTime();
        IQueryable<News> GetNewsByUserService(string name);

        //查询点赞数最多的攻略
        IQueryable<News> FindTopVoteService();
        IQueryable<NewsDetalis> GetNewsDetailByNews(int id);
        bool AddNewsCollect(int? newsId, int userNo);
    }
}
