using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Idal
{
    public interface IUserQueryDal
    {
        IQueryable<Scenic> QueryScenicByKeyWords(string keyWord);
        IQueryable<News> QueryNewsByKeyWords(string keyWord);
    }
}
