using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IEventParticipationService : IBusinessService<event_participation>
    {
        EventParticipation FindByID(int ID);
        new IEnumerable<EventParticipation> GetAll();
        bool Create(EventParticipation entity);
        bool Delete(EventParticipation entity);
        bool Update(EventParticipation entity);
    }
}
