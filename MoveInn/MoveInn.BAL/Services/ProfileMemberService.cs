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
    public class ProfileMemberService : BusinessService<profile_member>, IProfileMemberService
    {
        public ProfileMemberService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<profile_member, ProfileMember>();
        }

        public ProfileMemberService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<profile_member, ProfileMember>();
        }

        public ProfileMember FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<profile_member>();
            predicate = predicate.Or(p => p.ID == ID);
            var data = _unitOfWork.Repository<profile_member>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<profile_member, ProfileMember>(data);
        }

        public new IEnumerable<ProfileMember> GetAll()
        {
            var data = _unitOfWork.Repository<profile_member>().GetAll();
            return data.Select(p => Mapper.Map<profile_member, ProfileMember>(p));
        }

        public virtual bool Create(ProfileMember Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<ProfileMember, profile_member>(Model);
                _unitOfWork.Repository<profile_member>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(ProfileMember Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<ProfileMember, profile_member>(Model);
                _unitOfWork.Repository<profile_member>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(ProfileMember Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<ProfileMember, profile_member>(Model);
                _unitOfWork.Repository<profile_member>().Delete(entity);
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
