using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Idal
{
    public partial interface IAdminScenicDal:ICommonDal<AdminScenic>
    {
        //查询景区的操作记录，按时间排序
        IQueryable<AdminScenic> GetASByScenic(Scenic scenic);
    }
}
