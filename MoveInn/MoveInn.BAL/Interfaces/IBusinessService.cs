using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveInn.BAL.Interfaces
{
    public interface IBusinessService<T> : IService where T : class
    {
        IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
