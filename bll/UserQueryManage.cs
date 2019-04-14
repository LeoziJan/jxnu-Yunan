using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBLL;
using Model;
using Dal;

namespace bll
{
    public class UserQueryManage : IUserQueryManange, IDependency
    {
        private UserQueryDal userQueryDal = new UserQueryDal();
        public IQueryable<News> QueryNewsByKeyWords(string keyWord)
        {
            return userQueryDal.QueryNewsByKeyWords(keyWord);
        }

        public IQueryable<Scenic> QueryScenicByKeyWords(string keyWord)
        {
            return userQueryDal.QueryScenicByKeyWords(keyWord);
        }
    }
}
