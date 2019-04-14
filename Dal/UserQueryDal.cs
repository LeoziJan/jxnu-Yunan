using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Idal;
using Model;

namespace Dal
{
    public class UserQueryDal : IUserQueryDal
    {
        private DbContext db = DbEntity.Setdb();
        public IQueryable<News> QueryNewsByKeyWords(string keyWord)
        {
            var news= (from n in db.Set<News>()
                       where n.NewsTitle.Contains(keyWord)
                       orderby n.NewsVote descending
                       select n).Take(10);
            return news;
        }

        public IQueryable<Scenic> QueryScenicByKeyWords(string keyWord)
        {
            var scenic = (from s in db.Set<Scenic>()
                        where s.ScenicTitle.Contains(keyWord) ||s.ScenicKeyWord.Contains(keyWord)||s.City.Contains(keyWord)
                        orderby s.ScenicId descending
                        select s).Take(10);
            return scenic;
        }
    }
}
