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
    public class RightRoleService : BusinessService<right_role>, IRightRoleService
    {
        public RightRoleService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<right_role, RightRole>();
        }

        public RightRoleService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<right_role, RightRole>();
        }

        public RightRole FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<right_role>();
            predicate = predicate.Or(p => p.RowID == ID);
            var data = _unitOfWork.Repository<right_role>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<right_role, RightRole>(data);
        }

        public new IEnumerable<RightRole> GetAll()
        {
            var data = _unitOfWork.Repository<right_role>().GetAll();
            return data.Select(p => Mapper.Map<right_role, RightRole>(p));
        }

        public virtual bool Create(RightRole Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<RightRole, right_role>(Model);
                _unitOfWork.Repository<right_role>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(RightRole Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<RightRole, right_role>(Model);
                _unitOfWork.Repository<right_role>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(RightRole Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<RightRole, right_role>(Model);
                _unitOfWork.Repository<right_role>().Delete(entity);
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
