using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IRoleService : IBusinessService<role>
    {
        Role FindByID(int ID);
        new IEnumerable<Role> GetAll();
        bool Create(Role entity);
        bool Delete(Role entity);
        bool Update(Role entity);
    }
}
