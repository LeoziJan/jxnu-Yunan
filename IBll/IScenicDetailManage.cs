using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public partial interface IScenicDetailManage:ICommonManage<ScenicDetails>,IDependency
    {
        IQueryable<ScenicDetails> GetSDbyScenicService(Scenic sceinc);
    }
}
