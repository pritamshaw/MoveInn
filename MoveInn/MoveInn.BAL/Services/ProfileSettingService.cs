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
    public class ProfileSettingService : BusinessService<profile_setting>, IProfileSettingService
    {
        public ProfileSettingService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<profile_setting, ProfileSetting>();
        }

        public ProfileSettingService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<profile_setting, ProfileSetting>();
        }

        public ProfileSetting FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<profile_setting>();
            predicate = predicate.Or(p => p.ID == ID);
            var data = _unitOfWork.Repository<profile_setting>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<profile_setting, ProfileSetting>(data);
        }

        public new IEnumerable<ProfileSetting> GetAll()
        {
            var data = _unitOfWork.Repository<profile_setting>().GetAll();
            return data.Select(p => Mapper.Map<profile_setting, ProfileSetting>(p));
        }

        public virtual bool Create(ProfileSetting Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<ProfileSetting, profile_setting>(Model);
                _unitOfWork.Repository<profile_setting>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(ProfileSetting Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<ProfileSetting, profile_setting>(Model);
                _unitOfWork.Repository<profile_setting>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(ProfileSetting Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<ProfileSetting, profile_setting>(Model);
                _unitOfWork.Repository<profile_setting>().Delete(entity);
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
