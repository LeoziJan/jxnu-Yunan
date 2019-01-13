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
    public class AdminsDal:CommonDal<Admins>,IAdminsDal
    {
        private DbContext db = DbEntity.Setdb();
        public IQueryable<Admins> GetAdminByName(string AdminName)
        {
            var admins = from u in db.Set<Admins>()
                         where u.AdminName == AdminName
                         select u;
            return admins;
        }

        public Admins GetAdminById(int AdminId)
        {
            return db.Set<Admins>().Where(s => s.AdminId == AdminId).FirstOrDefault();
        }
    }
}
