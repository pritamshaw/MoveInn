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
    public class EventCategoryService : BusinessService<event_category>, IEventCategoryService
    {
        public EventCategoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<event_category, EventCategory>();
        }

        public EventCategoryService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<event_category, EventCategory>();
        }

        public EventCategory FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<event_category>();
            predicate = predicate.Or(p => p.RowID == ID);
            var data = _unitOfWork.Repository<event_category>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<event_category, EventCategory>(data);
        }

        public new IEnumerable<EventCategory> GetAll()
        {
            var data = _unitOfWork.Repository<event_category>().GetAll();
            return data.Select(p => Mapper.Map<event_category, EventCategory>(p));
        }

        public virtual bool Create(EventCategory Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<EventCategory, event_category>(Model);
                _unitOfWork.Repository<event_category>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(EventCategory Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<EventCategory, event_category>(Model);
                _unitOfWork.Repository<event_category>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(EventCategory Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<EventCategory, event_category>(Model);
                _unitOfWork.Repository<event_category>().Delete(entity);
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
