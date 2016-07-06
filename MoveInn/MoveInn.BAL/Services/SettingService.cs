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
    public class SettingService : BusinessService<setting>, ISettingService
    {
        public SettingService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<setting, Setting>();
        }

        public SettingService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<setting, Setting>();
        }

        public Setting FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<setting>();
            predicate = predicate.Or(p => p.ID == ID);
            var data = _unitOfWork.Repository<setting>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<setting, Setting>(data);
        }

        public new IEnumerable<Setting> GetAll()
        {
            var data = _unitOfWork.Repository<setting>().GetAll();
            return data.Select(p => Mapper.Map<setting, Setting>(p));
        }

        public virtual bool Create(Setting Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<Setting, setting>(Model);
                _unitOfWork.Repository<setting>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(Setting Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<Setting, setting>(Model);
                _unitOfWork.Repository<setting>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(Setting Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<Setting, setting>(Model);
                _unitOfWork.Repository<setting>().Delete(entity);
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
