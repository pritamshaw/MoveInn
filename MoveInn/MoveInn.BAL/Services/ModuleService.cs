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
    public class ModuleService : BusinessService<module>, IModuleService
    {
        public ModuleService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<module, Module>();
        }

        public ModuleService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<module, Module>();
        }

        public Module FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<module>();
            predicate = predicate.Or(p => p.RowID == ID);
            var data = _unitOfWork.Repository<module>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<module, Module>(data);
        }

        public new IEnumerable<Module> GetAll()
        {
            var data = _unitOfWork.Repository<module>().GetAll();
            return data.Select(p => Mapper.Map<module, Module>(p));
        }

        public virtual bool Create(Module Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<Module, module>(Model);
                _unitOfWork.Repository<module>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(Module Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<Module, module>(Model);
                _unitOfWork.Repository<module>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(Module Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<Module, module>(Model);
                _unitOfWork.Repository<module>().Delete(entity);
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
