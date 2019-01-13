using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;

namespace Dal
{
    public class DbEntity
    {
        public static DbContext Setdb()
        {
            //设计思想是想实现Dbccontext db=new YunanaEntities()  db.table 而不是 db.set<table>
            DbContext db = new YunanEntities();
            return db; 
        }
           
    }
}
