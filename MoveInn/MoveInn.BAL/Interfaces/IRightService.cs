using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IRightService : IBusinessService<right>
    {
        Right FindByID(int ID);
        new IEnumerable<Right> GetAll();
        bool Create(Right entity);
        bool Delete(Right entity);
        bool Update(Right entity);
    }
}
