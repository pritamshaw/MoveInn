using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Interfaces;
using MoveInn.DAL.Interfaces;
using MoveInn.DAL.Repository;
using MoveInn.DAL.UOW;

namespace MoveInn.BAL.Services
{
    public abstract class BusinessService<T> : IBusinessService<T> where T : class
    {
        public IUnitOfWork _unitOfWork;

        public BusinessService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _unitOfWork.Repository<T>().Add(entity);
            _unitOfWork.Commit();
        }


        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _unitOfWork.Repository<T>().Edit(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _unitOfWork.Repository<T>().Delete(entity);
            _unitOfWork.Commit();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _unitOfWork.Repository<T>().GetAll();
        }

        public virtual IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork.Repository<T>().FindBy(predicate);
        }
    }
}
