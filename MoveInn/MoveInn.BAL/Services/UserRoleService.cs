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
    public class UserRoleService : BusinessService<user_role>, IUserRoleService
    {
        public UserRoleService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<user_role, UserRole>();
        }

        public UserRoleService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<user_role, UserRole>();
        }

        public UserRole FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<user_role>();
            predicate = predicate.Or(p => p.ID == ID);
            var data = _unitOfWork.Repository<user_role>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<user_role, UserRole>(data);
        }

        public new IEnumerable<UserRole> GetAll()
        {
            var data = _unitOfWork.Repository<user_role>().GetAll();
            return data.Select(p => Mapper.Map<user_role, UserRole>(p));
        }

        public virtual bool Create(UserRole Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<UserRole, user_role>(Model);
                _unitOfWork.Repository<user_role>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(UserRole Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<UserRole, user_role>(Model);
                _unitOfWork.Repository<user_role>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(UserRole Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<UserRole, user_role>(Model);
                _unitOfWork.Repository<user_role>().Delete(entity);
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
