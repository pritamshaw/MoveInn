using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IRightRoleService : IBusinessService<right_role>
    {
        RightRole FindByID(int ID);
        new IEnumerable<RightRole> GetAll();
        bool Create(RightRole entity);
        bool Delete(RightRole entity);
        bool Update(RightRole entity);
    }
}
