using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IEventCategoryService : IBusinessService<event_category>
    {
        EventCategory FindByID(int ID);
        new IEnumerable<EventCategory> GetAll();
        bool Create(EventCategory entity);
        bool Delete(EventCategory entity);
        bool Update(EventCategory entity);
    }
}
