using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface IUserQueryManange
    {
        IQueryable<Scenic> QueryScenicByKeyWords(string keyWord);
        IQueryable<News> QueryNewsByKeyWords(string keyWord);

    }
}
