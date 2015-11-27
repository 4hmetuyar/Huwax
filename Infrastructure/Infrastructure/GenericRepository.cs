using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Huwax.Dal;
using Infrastructure.Interfaces;

namespace Infrastructure.Infrastructure
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Commit();
        void Delete(Expression<Func<TEntity, bool>> where);
        TEntity GetById(long id);
        TEntity GetById(string id);
        TEntity Get(Expression<Func<TEntity, bool>> where);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
    }


    // IMPLEMENTATION

    public abstract class GenericRepository<T> where T : class
    {
        private HuwaxEntities _dataContext;
        private readonly IDbSet<T> _dbSet;

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected HuwaxEntities DataContext
        {
            get { return _dataContext ?? (_dataContext = DatabaseFactory.Get()); }
        }

        protected GenericRepository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _dbSet = DataContext.Set<T>();
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Attach(entity);
            _dataContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Commit()
        {
            try
            {
                _dataContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    foreach (var ve in eve.ValidationErrors)
                    {
                        throw new Exception(ve.PropertyName + ": " + ve.ErrorMessage);
                    }
                }
            }

        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = _dbSet.Where<T>(where).AsEnumerable();

            foreach (T obj in objects)
            {
                _dbSet.Remove(obj);
            }
        }

        public virtual T GetById(long id)
        {
            return _dbSet.Find(id);
        }

        public virtual T GetById(string id)
        {
            return _dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).FirstOrDefault<T>();
        }
    }
}
