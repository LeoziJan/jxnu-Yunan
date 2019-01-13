using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;
using IBLL;
using Dal;
using System.Linq.Expressions;

namespace bll
{
    public partial class CommonManage<T> : ICommonManage<T> where T : class, new()
    {
        private CommonDal<T> ac = new CommonDal<T>();      
        public T AddService(T entity)
        {           
            return ac.Add(entity);
        }

        public bool deleteService(int tid)
        {
            return ac.delete(tid);
        }

        public bool deteleService(T entity)
        {
            return ac.detele(entity);
        }

        public IQueryable<T> LoadService()
        {
            return ac.LoadEntities();
        }
       
        public IQueryable<T> LoadService(Expression<Func<T, bool>> lambda)
        {
            return ac.LoadEntities(lambda);
        }

        public bool updateServic(T entity)
        {
           return ac.update(entity);
            
        }
    }
}
