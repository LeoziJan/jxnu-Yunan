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
    public partial class AdminScenicManage : CommonManage<AdminScenic>, IAdminScenicManage
    {
        //私有字段，考虑采用工厂模式
        private AdminScenicDal asd = new AdminScenicDal();
        /// <summary>
        /// 查询管理员景区操作记录
        /// </summary>
        /// <param name="scenic">景区</param>
        /// <returns></returns>
        public IQueryable<AdminScenic> GetASByScenicService(Scenic scenic)
        {
            return asd.GetASByScenic(scenic);
        }
    }
}
