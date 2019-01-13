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
    public partial class TalksManage : CommonManage<Talks>, ITalksManage
    {
        private TalksDal td = new TalksDal();

        /// <summary>
        /// 查询一条攻略的评论数
        /// </summary>
        /// <param name="news">攻略</param>
        /// <returns></returns>
        public int NewsTalksCount(News news)
        {
            return td.GetTalksCount(news);
        }

        /// <summary>
        /// 查询攻略的所有评论
        /// </summary>
        /// <param name="news">攻略</param>
        /// <returns></returns>
        public IQueryable<Talks> NewsTalksService(News news)
        {
            return td.GetTalksByNews(news);
        }

        /// <summary>
        /// 查询用户的所有评论
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns></returns>
        public IQueryable<Talks> UserTalksService(Users user)
        {
            return td.GetTalksByUser(user);
        }

    }
}
