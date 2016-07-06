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
    public class ProfileCategoryService : BusinessService<profile_category>, IProfileCategoryService
    {
        public ProfileCategoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<profile_category, ProfileCategory>();
        }

        public ProfileCategoryService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<profile_category, ProfileCategory>();
        }

        public ProfileCategory FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<profile_category>();
            predicate = predicate.Or(p => p.RowID == ID);
            var data = _unitOfWork.Repository<profile_category>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<profile_category, ProfileCategory>(data);
        }

        public new IEnumerable<ProfileCategory> GetAll()
        {
            var data = _unitOfWork.Repository<profile_category>().GetAll();
            return data.Select(p => Mapper.Map<profile_category, ProfileCategory>(p));
        }

        public virtual bool Create(ProfileCategory Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<ProfileCategory, profile_category>(Model);
                _unitOfWork.Repository<profile_category>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(ProfileCategory Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<ProfileCategory, profile_category>(Model);
                _unitOfWork.Repository<profile_category>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(ProfileCategory Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<ProfileCategory, profile_category>(Model);
                _unitOfWork.Repository<profile_category>().Delete(entity);
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
