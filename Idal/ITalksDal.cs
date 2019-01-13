using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Idal
{
    //扩展接口icommondal
    public partial interface ITalksDal:ICommonDal<Talks>
    {
        //按用户查找评论
        IQueryable<Talks> GetTalksByUser(Users user);

        //按攻略查找评论
        IQueryable<Talks> GetTalksByNews(News news);

        //计算帖子总评论数
        int GetTalksCount(News news);


        //要用到设计模式，排序方式封装
        ////按时间排序
        //IQueryable<Talks> GetTalksByTime();
    }
}
