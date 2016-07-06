using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface IParticipationCategoryService : IBusinessService<participation_category>
    {
        ParticipationCategory FindByID(int ID);
        new IEnumerable<ParticipationCategory> GetAll();
        bool Create(ParticipationCategory entity);
        bool Delete(ParticipationCategory entity);
        bool Update(ParticipationCategory entity);
    }
}
