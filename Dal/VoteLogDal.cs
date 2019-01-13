using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Idal;
using Model;
using System.Data.Entity;

namespace Dal
{
    public class VoteLogDal : CommonDal<VoteLog>, IVotelogDal
    {
        DbContext db = DbEntity.Setdb();
        public IQueryable<VoteLog> GetVotelogByNewsUser(int userId, int newsId)
        {
            var votelog = (from v in db.Set<VoteLog>()
                           where v.UserId == userId & v.NewsId == newsId
                           select v
                         );
            return votelog;
        }        
    }
}
