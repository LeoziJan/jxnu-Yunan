using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IBLL
{
    public interface IVoteLogManage:ICommonManage<VoteLog>,IDependency
    {
        VoteLog GetVoteLogByNewsUser(int userid, int newsId);
    }
}
