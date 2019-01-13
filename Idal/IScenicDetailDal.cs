using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Idal
{
    public interface IScenicDetailDal:ICommonDal<ScenicDetails>
    {
        IQueryable<ScenicDetails> GetSDetailbyScenic(Scenic sceinc);
    }
}
