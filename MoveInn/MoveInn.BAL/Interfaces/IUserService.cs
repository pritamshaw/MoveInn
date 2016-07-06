using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IUserService : IBusinessService<user>
    {
        User FindByID(int ID);
        User FindByCredentials(string Email, string Password);
        new IEnumerable<User> GetAll();
        bool Create(User entity);
        bool Delete(User entity);
        bool Update(User entity);
    }
}
