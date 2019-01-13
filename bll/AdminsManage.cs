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
    public partial class AdminsManage:CommonManage<Admins>,IAdminsManage
    {
        //
        private AdminsDal adm = new AdminsDal();

        public IQueryable<Admins> GetAdminByName(string AdminName)
        {
            return adm.GetAdminByName(AdminName);
        }

        public Admins GetAdminById(int adminId)
        {
            return adm.GetAdminById(adminId);
        }
    }
}
