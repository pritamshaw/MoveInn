using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IModuleCategoryService : IBusinessService<module_category>
    {
        ModuleCategory FindByID(int ID);
        new IEnumerable<ModuleCategory> GetAll();
        bool Create(ModuleCategory entity);
        bool Delete(ModuleCategory entity);
        bool Update(ModuleCategory entity);
    }
}
