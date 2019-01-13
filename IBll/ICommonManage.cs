using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;
using System.Linq.Expressions;

namespace IBLL
{
    public partial interface ICommonManage<T>
    {
        T AddService(T entity);
        bool updateServic(T entity);
        bool deteleService(T entity);
        bool deleteService(int tid);

        //查询T方法的重载
        IQueryable<T> LoadService();
        IQueryable<T> LoadService(Expression<Func<T, bool>> lambda);
    }
}
