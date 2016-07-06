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
    public class ProfileModuleService : BusinessService<profile_module>, IProfileModuleService
    {
        public ProfileModuleService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<profile_module, ProfileModule>();
        }

        public ProfileModuleService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<profile_module, ProfileModule>();
        }

        public ProfileModule FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<profile_module>();
            predicate = predicate.Or(p => p.ID == ID);
            var data = _unitOfWork.Repository<profile_module>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<profile_module, ProfileModule>(data);
        }

        public new IEnumerable<ProfileModule> GetAll()
        {
            var data = _unitOfWork.Repository<profile_module>().GetAll();
            return data.Select(p => Mapper.Map<profile_module, ProfileModule>(p));
        }

        public virtual bool Create(ProfileModule Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<ProfileModule, profile_module>(Model);
                _unitOfWork.Repository<profile_module>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(ProfileModule Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<ProfileModule, profile_module>(Model);
                _unitOfWork.Repository<profile_module>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(ProfileModule Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<ProfileModule, profile_module>(Model);
                _unitOfWork.Repository<profile_module>().Delete(entity);
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
