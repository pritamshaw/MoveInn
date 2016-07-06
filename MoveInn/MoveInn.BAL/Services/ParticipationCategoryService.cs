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
    public class ParticipationCategoryService : BusinessService<participation_category>, IParticipationCategoryService
    {
        public ParticipationCategoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<participation_category, ParticipationCategory>();
        }

        public ParticipationCategoryService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<participation_category, ParticipationCategory>();
        }

        public ParticipationCategory FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<participation_category>();
            predicate = predicate.Or(p => p.RowID == ID);
            var data = _unitOfWork.Repository<participation_category>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<participation_category, ParticipationCategory>(data);
        }

        public new IEnumerable<ParticipationCategory> GetAll()
        {
            var data = _unitOfWork.Repository<participation_category>().GetAll();
            return data.Select(p => Mapper.Map<participation_category, ParticipationCategory>(p));
        }

        public virtual bool Create(ParticipationCategory Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<ParticipationCategory, participation_category>(Model);
                _unitOfWork.Repository<participation_category>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(ParticipationCategory Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<ParticipationCategory, participation_category>(Model);
                _unitOfWork.Repository<participation_category>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(ParticipationCategory Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<ParticipationCategory, participation_category>(Model);
                _unitOfWork.Repository<participation_category>().Delete(entity);
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
