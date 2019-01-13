using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;
using Idal;

namespace Dal
{
    public class NewsDal : CommonDal<News>, INewsDal
    {
        private DbContext db = DbEntity.Setdb();
        public IQueryable<News> FindTopVote()
        {
            var news = (from n in db.Set<News>()
                       orderby n.NewsVote descending
                       select n).Take(5);
            return news;

            //var news =( from n in db.Set<News>()
            //           orderby n.NewsVote ascending
            //           select n).Take(5);
        }

        public IQueryable<News> GetNewsByTime()
        {
            var news = from n in db.Set<News>()
                       orderby n.PostTime descending
                       select n;
            return news;
        }

        public IQueryable<News> GetNewsByUser(string name)
        {
            var news = from n in db.Set<News>()
                       where n.User.UserName == name
                       orderby n.PostTime descending
                       select n;
            return news;
        }
    }
}
