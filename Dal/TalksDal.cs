using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Idal;
using System.Data.Entity;

namespace Dal
{
    public class TalksDal : CommonDal<Talks>, ITalksDal
    {
        private DbContext db = DbEntity.Setdb();              
        public IQueryable<Talks> GetTalksByNews(News news)
        {           
            var talks = (
                from t in db.Set<Talks>()
                where t.NewsId == news.NewsId
                select t);
                return talks;
        }

        public IQueryable<Talks> GetTalksByUser(Users user)
        {
            var talks = (
                from t in db.Set<Talks>()
                where t.UserId==user.UserId
                select t);
            return talks;
        }

        public int GetTalksCount(News news)
        {
            var count = (
                from t in db.Set<Talks>()
                where t.NewsId==news.NewsId               
                select t).Count();
            return count;
        }
    }
}
