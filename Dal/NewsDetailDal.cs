using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.Entity;

namespace Dal
{
    public class NewsDetailDal:CommonDal<NewsDetalis>
    {
        private DbContext db = new YunanEntities();

        public IQueryable<NewsDetalis> GetNewsDeatilByNews(int id)
        {
            var newsdetail = from n in db.Set<NewsDetalis>()
                             where n.NewsId == id
                             select n;
            return newsdetail;
        }
    }
}
