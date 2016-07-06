using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IProfileService : IBusinessService<profile>
    {
        Profile FindByID(int ID);
        new IEnumerable<Profile> GetAll();
        bool Create(Profile entity);
        bool Delete(Profile entity);
        bool Update(Profile entity);
    }
}
