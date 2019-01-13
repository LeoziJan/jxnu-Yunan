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
    public class AdminScenicDal : CommonDal<AdminScenic>, IAdminScenicDal
    {
        private DbContext db = DbEntity.Setdb();
        public IQueryable<AdminScenic> GetASByScenic(Scenic scenic)
        {
            var adminscenic = from a in db.Set<AdminScenic>()
                              join m in db.Set<Admins>() on a.AdminId equals m.AdminId
                              where a.ScenicId == scenic.ScenicId
                              orderby a.ActTime ascending
                              select a;
            return adminscenic; 
        }
    }
}
