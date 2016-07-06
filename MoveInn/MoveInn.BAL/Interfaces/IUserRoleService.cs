using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IUserRoleService : IBusinessService<user_role>
    {
        UserRole FindByID(int ID);
        new IEnumerable<UserRole> GetAll();
        bool Create(UserRole entity);
        bool Delete(UserRole entity);
        bool Update(UserRole entity);
    }
}
