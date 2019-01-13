using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Idal;
using System.Data.Entity;
using System.Linq.Expressions;

namespace Dal
{
    public class ScenicDetailDal : CommonDal<ScenicDetails>, IScenicDetailDal
    {
        private DbContext db = DbEntity.Setdb();

        public IQueryable<ScenicDetails> GetSDetailbyScenic(Scenic sceinc)
        {

            var scenicdetail = (
                from s in db.Set<ScenicDetails>()
                where s.ScenicId == sceinc.ScenicId
                select s);
            return scenicdetail;                  
        }       
    }
}
