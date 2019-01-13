using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using IBLL;
using Dal;

namespace bll
{
    public partial class ScenicDetailManage : CommonManage<ScenicDetails>, IScenicDetailManage
    {
        private ScenicDetailDal sdd = new ScenicDetailDal();
        /// <summary>
        /// 查询景区包含的景点
        /// </summary>
        /// <param name="sceinc">景区</param>
        /// <returns></returns>
        public IQueryable<ScenicDetails> GetSDbyScenicService(Scenic sceinc)
        {
            return sdd.GetSDetailbyScenic(sceinc);
        }
    }
}
