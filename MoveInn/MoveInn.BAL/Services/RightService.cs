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
    public class RightService : BusinessService<right>, IRightService
    {
        public RightService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<right, Right>();
        }

        public RightService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<right, Right>();
        }

        public Right FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<right>();
            predicate = predicate.Or(p => p.RowID == ID);
            var data = _unitOfWork.Repository<right>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<right, Right>(data);
        }

        public new IEnumerable<Right> GetAll()
        {
            var data = _unitOfWork.Repository<right>().GetAll();
            return data.Select(p => Mapper.Map<right, Right>(p));
        }

        public virtual bool Create(Right Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<Right, right>(Model);
                _unitOfWork.Repository<right>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(Right Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<Right, right>(Model);
                _unitOfWork.Repository<right>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(Right Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<Right, right>(Model);
                _unitOfWork.Repository<right>().Delete(entity);
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
