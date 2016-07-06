using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IProfileSettingService : IBusinessService<profile_setting>
    {
        ProfileSetting FindByID(int ID);
        new IEnumerable<ProfileSetting> GetAll();
        bool Create(ProfileSetting entity);
        bool Delete(ProfileSetting entity);
        bool Update(ProfileSetting entity);
    }
}
