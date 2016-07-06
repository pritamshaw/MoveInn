using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IProfileModuleService : IBusinessService<profile_module>
    {
        ProfileModule FindByID(int ID);
        new IEnumerable<ProfileModule> GetAll();
        bool Create(ProfileModule entity);
        bool Delete(ProfileModule entity);
        bool Update(ProfileModule entity);
    }
}
