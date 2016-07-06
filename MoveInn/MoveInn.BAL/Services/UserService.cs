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
    public class UserService : BusinessService<user>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<user, User>();
        }

        public UserService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<user, User>();
        }

        public User FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<user>();
            predicate = predicate.Or(p => p.RowID == ID);
            var data = _unitOfWork.Repository<user>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<user, User>(data);
        }

        public User FindByCredentials(string Email, string Password)
        {
            var predicate = PredicateBuilder.True<user>();
            predicate = predicate.And(p => p.Email == Email && p.Password == Password);
            var data = _unitOfWork.Repository<user>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<user, User>(data);
        }

        public new IEnumerable<User> GetAll()
        {
            var data = _unitOfWork.Repository<user>().GetAll();
            return data.Select(p => Mapper.Map<user, User>(p));
        }

        public virtual bool Create(User Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.DynamicMap<User, user>(Model);
                _unitOfWork.Repository<user>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(User Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.DynamicMap<User, user>(Model);
                _unitOfWork.Repository<user>().Edit(entity);
                _unitOfWork.Repository<user>().Save();
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(User Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.DynamicMap<User, user>(Model);
                _unitOfWork.Repository<user>().Delete(entity);
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
