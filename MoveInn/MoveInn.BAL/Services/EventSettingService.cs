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
    public class EventSettingService : BusinessService<event_setting>, IEventSettingService
    {
        public EventSettingService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<event_setting, EventSetting>();
        }

        public EventSettingService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<event_setting, EventSetting>();
        }

        public EventSetting FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<event_setting>();
            predicate = predicate.Or(p => p.RowID == ID);
            var data = _unitOfWork.Repository<event_setting>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<event_setting, EventSetting>(data);
        }

        public new IEnumerable<EventSetting> GetAll()
        {
            var data = _unitOfWork.Repository<event_setting>().GetAll();
            return data.Select(p => Mapper.Map<event_setting, EventSetting>(p));
        }

        public virtual bool Create(EventSetting Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<EventSetting, event_setting>(Model);
                _unitOfWork.Repository<event_setting>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(EventSetting Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<EventSetting, event_setting>(Model);
                _unitOfWork.Repository<event_setting>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(EventSetting Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<EventSetting, event_setting>(Model);
                _unitOfWork.Repository<event_setting>().Delete(entity);
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
