using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using MoveInn.DAL.EntityModel;
using System.Linq.Expressions;
using MoveInn.DAL.Interfaces;
using LinqKit;

namespace MoveInn.DAL.Repository
{

    public class Repository<T> : IRepository<T>
          where T : class
    {
        protected MoveInnEntities _entities;
        protected readonly IDbSet<T> _dbset;

        public Repository(MoveInnEntities context)
        {
            _entities = context;
            _dbset = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable<T>();
        }

        public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> query = _dbset.AsExpandable().Where(predicate).AsEnumerable();
            return query;
        }

        public virtual T Add(T entity)
        {
            return _dbset.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            return _dbset.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }
    }
}
