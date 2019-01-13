using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Idal;


namespace Dal
{
    public partial class CommonDal<T>:DbEntity,ICommonDal<T> where T:class,new() 
    {
        private DbContext db = DbEntity.Setdb();

        public  T Add(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
            return entity;
        }

        public bool delete(int tid)
        {
            var entity = db.Set<T>().Find(tid);
            if (entity != null)
            {
                db.Set<T>().Remove(entity);
                db.SaveChanges();
                return true;
            }
            else
            return false;
        }

        public bool detele(T entity)
        {
            db.Set<T>().Remove(entity);
            db.SaveChanges();
            //db.Entry(entity).State = EntityState.Deleted;
            return true;
        }      

        public IQueryable<T> LoadEntities()
        {
            var all = from a in db.Set<T>()
                      select a;
            return all;
        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> lambda)
        {
            return db.Set<T>().Where(lambda).AsQueryable();
        }

        public bool update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();           
            return true;
        }
    }
}
