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
    public class ProfileService : BusinessService<profile>, IProfileService
    {
        public ProfileService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<profile, MoveInn.BAL.Models.Profile>();
        }

        public ProfileService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<profile, MoveInn.BAL.Models.Profile>();
        }

        public MoveInn.BAL.Models.Profile FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<profile>();
            predicate = predicate.Or(p => p.RowID == ID);
            var data = _unitOfWork.Repository<profile>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<profile, MoveInn.BAL.Models.Profile>(data);
        }

        public new IEnumerable<MoveInn.BAL.Models.Profile> GetAll()
        {
            var data = _unitOfWork.Repository<profile>().GetAll();
            return data.Select(p => Mapper.Map<profile, MoveInn.BAL.Models.Profile>(p));
        }

        public virtual bool Create(MoveInn.BAL.Models.Profile Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<MoveInn.BAL.Models.Profile, profile>(Model);
                _unitOfWork.Repository<profile>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(MoveInn.BAL.Models.Profile Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<MoveInn.BAL.Models.Profile, profile>(Model);
                _unitOfWork.Repository<profile>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(MoveInn.BAL.Models.Profile Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<MoveInn.BAL.Models.Profile, profile>(Model);
                _unitOfWork.Repository<profile>().Delete(entity);
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
