using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Idal
{
    public interface IVotelogDal:ICommonDal<VoteLog>
    {
        IQueryable<VoteLog> GetVotelogByNewsUser(int userId, int newsId);       

    }
}
