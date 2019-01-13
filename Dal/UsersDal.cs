using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;
using Idal;

namespace Dal
{
    public class UsersDal:CommonDal<Users>,IUsersDal
    {
        private DbContext db = DbEntity.Setdb();
        //
    }
}
