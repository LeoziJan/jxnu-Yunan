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
    public class VoteLogManage : CommonManage<VoteLog>, IVoteLogManage
    {
        private VoteLogDal vldal = new VoteLogDal();
        public VoteLog GetVoteLogByNewsUser(int userid, int newsId)
        {
            return vldal.GetVotelogByNewsUser(userid, newsId).FirstOrDefault();
        }
    }
}
