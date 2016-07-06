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
    public class RoleService : BusinessService<role>, IRoleService
    {
        public RoleService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<role, Role>();
        }

        public RoleService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<role, Role>();
        }

        public Role FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<role>();
            predicate = predicate.Or(p => p.RowID == ID);
            var data = _unitOfWork.Repository<role>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<role, Role>(data);
        }

        public new IEnumerable<Role> GetAll()
        {
            var data = _unitOfWork.Repository<role>().GetAll();
            return data.Select(p => Mapper.Map<role, Role>(p));
        }

        public virtual bool Create(Role Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<Role, role>(Model);
                _unitOfWork.Repository<role>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(Role Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<Role, role>(Model);
                _unitOfWork.Repository<role>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(Role Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<Role, role>(Model);
                _unitOfWork.Repository<role>().Delete(entity);
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
