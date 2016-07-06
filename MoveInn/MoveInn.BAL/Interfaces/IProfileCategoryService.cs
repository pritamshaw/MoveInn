using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IProfileCategoryService : IBusinessService<profile_category>
    {
        ProfileCategory FindByID(int ID);
        new IEnumerable<ProfileCategory> GetAll();
        bool Create(ProfileCategory entity);
        bool Delete(ProfileCategory entity);
        bool Update(ProfileCategory entity);
    }
}
