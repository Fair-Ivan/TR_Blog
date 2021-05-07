namespace TR.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using TR.IRepositories;
    using TR.Models;

    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        protected TrContext db;

        public BaseRepository(TrContext trContext)
        {
            db = trContext;
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().FirstOrDefault(expression);
        }

        public bool IsExist(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().Any(expression);
        }

        public List<T> List(Expression<Func<T, bool>> expression)
        {
            return db.Set<T>().Where(expression).ToList();
        }

        public async Task<List<T>> ListAsync(Expression<Func<T, bool>> expression)
        {
            return await db.Set<T>().Where(expression).ToListAsync();
        }

        public bool Save(T entity)
        {
            db.Set<T>().Add(entity);
            if (db.SaveChanges() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        public bool SaveList(List<T> entity)
        {
            bool result = false;
            if (entity == null || entity.Count == 0)
            {
                return result;
            }
            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    entity.ForEach(item =>
                    {
                        db.Set<T>().Add(item);
                    });
                    db.SaveChanges();
                    tran.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    result = false;
                    tran.Rollback();
                    throw new Exception(ex.ToString());
                }
            }
            return result;
        }

        public bool Update(T entity)
        {
            db.Set<T>().Update(entity);
            return db.SaveChanges() > 0;
        }

        public bool UpdateList(List<T> entity)
        {
            bool result = false;
            if (entity == null || entity.Count == 0)
            {
                return result;
            }

            using (var tran = db.Database.BeginTransaction())
            {
                try
                {
                    entity.ForEach(item =>
                    {
                        db.Set<T>().Update(item);
                    });
                    result = db.SaveChanges() > 0 ? true : false;
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    result = false;
                    tran.Rollback();
                    throw new Exception(ex.ToString());
                }
            }
            return result;
        }
    }
}
