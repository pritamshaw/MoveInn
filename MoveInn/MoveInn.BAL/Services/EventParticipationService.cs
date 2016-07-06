using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.DAL.EntityModel;
using MoveInn.DAL.Interfaces;
using MoveInn.BAL.Interfaces;
using MoveInn.BAL.Models;
using AutoMapper;
using LinqKit;
using MoveInn.DAL.UOW;

namespace MoveInn.BAL.Services
{
    public class EventParticipationService : BusinessService<event_participation>, IEventParticipationService
    {
        public EventParticipationService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<event_participation, EventParticipation>();
        }

        public EventParticipationService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<event_participation, EventParticipation>();
        }

        public EventParticipation FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<event_participation>();
            predicate = predicate.Or(p => p.RowID == ID);
            var data = _unitOfWork.Repository<event_participation>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<event_participation, EventParticipation>(data);
        }

        public new IEnumerable<EventParticipation> GetAll()
        {
            var data = _unitOfWork.Repository<event_participation>().GetAll();
            return data.Select(p => Mapper.Map<event_participation, EventParticipation>(p));
        }

        public virtual bool Create(EventParticipation Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<EventParticipation, event_participation>(Model);
                _unitOfWork.Repository<event_participation>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(EventParticipation Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<EventParticipation, event_participation>(Model);
                _unitOfWork.Repository<event_participation>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(EventParticipation Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<EventParticipation, event_participation>(Model);
                _unitOfWork.Repository<event_participation>().Delete(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

    }
}
