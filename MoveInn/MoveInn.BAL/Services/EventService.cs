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
    public class EventService : BusinessService<@event>, IEventService
    {
        public EventService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<@event, Event>();
        }

        public EventService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<@event, Event>();
        }

        public Event FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<@event>();
            predicate = predicate.Or(p => p.RowID == ID);
            var data = _unitOfWork.Repository<@event>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<@event, Event>(data);
        }

        public new IEnumerable<Event> GetAll()
        {
            var data = _unitOfWork.Repository<@event>().GetAll();
            return data.Select(p => Mapper.Map<@event, Event>(p));
        }

        public virtual bool Create(Event Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<Event, @event>(Model);
                _unitOfWork.Repository<@event>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(Event Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<Event, @event>(Model);
                _unitOfWork.Repository<@event>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(Event Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<Event, @event>(Model);
                _unitOfWork.Repository<@event>().Delete(entity);
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
