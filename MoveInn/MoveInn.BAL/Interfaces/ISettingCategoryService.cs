using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface ISettingCategoryService : IBusinessService<setting_category>
    {
        SettingCategory FindByID(int ID);
        new IEnumerable<SettingCategory> GetAll();
        bool Create(SettingCategory entity);
        bool Delete(SettingCategory entity);
        bool Update(SettingCategory entity);
    }
}
