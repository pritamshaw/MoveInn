using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IUserSettingService : IBusinessService<user_setting>
    {
        UserSetting FindByID(int ID);
        new IEnumerable<UserSetting> GetAll();
        bool Create(UserSetting entity);
        bool Delete(UserSetting entity);
        bool Update(UserSetting entity);
    }
}
