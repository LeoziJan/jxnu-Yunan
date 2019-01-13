using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public partial interface IAdminScenicManage:ICommonManage<AdminScenic>, IDependency
    {
        //查询景区的操作记录，按时间排序
        IQueryable<AdminScenic> GetASByScenicService(Scenic scenic);
    }
}
