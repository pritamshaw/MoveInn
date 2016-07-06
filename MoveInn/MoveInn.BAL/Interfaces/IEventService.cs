using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IEventService : IBusinessService<@event>
    {
        Event FindByID(int ID);
        new IEnumerable<Event> GetAll();
        bool Create(Event entity);
        bool Delete(Event entity);
        bool Update(Event entity);
    }
}
