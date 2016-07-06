using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IEventSettingService : IBusinessService<event_setting>
    {
        EventSetting FindByID(int ID);
        new IEnumerable<EventSetting> GetAll();
        bool Create(EventSetting entity);
        bool Delete(EventSetting entity);
        bool Update(EventSetting entity);
    }
}
