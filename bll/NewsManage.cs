using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Dal;
using IBLL;

namespace bll
{
    public partial class NewsManage : CommonManage<News>, INewsManage
    {
        private NewsDal nd = new NewsDal();
        private NewsDetailDal ndd = new NewsDetailDal();
        /// <summary>
        /// 查询点赞数最高的攻略
        /// </summary>
        /// <returns></returns>
        public IQueryable<News> FindTopVoteService()
        {
            return nd.FindTopVote();
        }

        /// <summary>
        /// 按事件先后查询攻略
        /// </summary>
        /// <returns></returns>
        public IQueryable<News> GetNewsByTime()
        {
            return nd.GetNewsByTime();
        }

        /// <summary>
        /// 查询用户的攻略
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        public IQueryable<News> GetNewsByUserService(string name)
        {
            return nd.GetNewsByUser(name);
        }

        public IQueryable<NewsDetalis> GetNewsDetailByNews(int id)
        {
            return ndd.GetNewsDeatilByNews(id);
        }
    }
}
