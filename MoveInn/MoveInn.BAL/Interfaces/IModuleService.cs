using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IModuleService : IBusinessService<module>
    {
        Module FindByID(int ID);
        new IEnumerable<Module> GetAll();
        bool Create(Module entity);
        bool Delete(Module entity);
        bool Update(Module entity);
    }
}
