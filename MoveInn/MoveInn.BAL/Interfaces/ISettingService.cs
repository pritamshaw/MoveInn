using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface ISettingService : IBusinessService<setting>
    {
        Setting FindByID(int ID);
        new IEnumerable<Setting> GetAll();
        bool Create(Setting entity);
        bool Delete(Setting entity);
        bool Update(Setting entity);
    }
}
