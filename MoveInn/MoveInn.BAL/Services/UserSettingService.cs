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
    public class UserSettingService : BusinessService<user_setting>, IUserSettingService
    {
        public UserSettingService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<user_setting, UserSetting>();
        }

        public UserSettingService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<user_setting, UserSetting>();
        }

        public UserSetting FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<user_setting>();
            predicate = predicate.Or(p => p.ID == ID);
            var data = _unitOfWork.Repository<user_setting>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<user_setting, UserSetting>(data);
        }

        public new IEnumerable<UserSetting> GetAll()
        {
            var data = _unitOfWork.Repository<user_setting>().GetAll();
            return data.Select(p => Mapper.Map<user_setting, UserSetting>(p));
        }

        public virtual bool Create(UserSetting Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<UserSetting, user_setting>(Model);
                _unitOfWork.Repository<user_setting>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(UserSetting Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<UserSetting, user_setting>(Model);
                _unitOfWork.Repository<user_setting>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(UserSetting Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<UserSetting, user_setting>(Model);
                _unitOfWork.Repository<user_setting>().Delete(entity);
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
