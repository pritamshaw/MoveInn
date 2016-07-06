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
    public class SettingCategoryService : BusinessService<setting_category>, ISettingCategoryService
    {
        public SettingCategoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<setting_category, SettingCategory>();
        }

        public SettingCategoryService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<setting_category, SettingCategory>();
        }

        public SettingCategory FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<setting_category>();
            predicate = predicate.Or(p => p.ID == ID);
            var data = _unitOfWork.Repository<setting_category>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<setting_category, SettingCategory>(data);
        }

        public new IEnumerable<SettingCategory> GetAll()
        {
            var data = _unitOfWork.Repository<setting_category>().GetAll();
            return data.Select(p => Mapper.Map<setting_category, SettingCategory>(p));
        }

        public virtual bool Create(SettingCategory Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<SettingCategory, setting_category>(Model);
                _unitOfWork.Repository<setting_category>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(SettingCategory Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<SettingCategory, setting_category>(Model);
                _unitOfWork.Repository<setting_category>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(SettingCategory Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<SettingCategory, setting_category>(Model);
                _unitOfWork.Repository<setting_category>().Delete(entity);
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
