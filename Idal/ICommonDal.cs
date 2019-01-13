using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Linq.Expressions;

namespace Idal
{
    //声明一个泛型接口定义实体的增删改查
    public partial interface ICommonDal<T>
    {
        T Add(T entity);
        bool update(T entity);
        bool detele(T entity);
        bool delete(int tid);
        IQueryable<T> LoadEntities();
        IQueryable<T> LoadEntities(Expression<Func<T,bool>> lambda);      
    }
}
