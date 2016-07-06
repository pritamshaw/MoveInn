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
    public class ModuleCategoryService : BusinessService<module_category>, IModuleCategoryService
    {
        public ModuleCategoryService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<module_category, ModuleCategory>();
        }

        public ModuleCategoryService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<module_category, ModuleCategory>();
        }

        public ModuleCategory FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<module_category>();
            predicate = predicate.Or(p => p.RowID == ID);
            var data = _unitOfWork.Repository<module_category>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<module_category, ModuleCategory>(data);
        }

        public new IEnumerable<ModuleCategory> GetAll()
        {
            var data = _unitOfWork.Repository<module_category>().GetAll();
            return data.Select(p => Mapper.Map<module_category, ModuleCategory>(p));
        }

        public virtual bool Create(ModuleCategory Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<ModuleCategory, module_category>(Model);
                _unitOfWork.Repository<module_category>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(ModuleCategory Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<ModuleCategory, module_category>(Model);
                _unitOfWork.Repository<module_category>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(ModuleCategory Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<ModuleCategory, module_category>(Model);
                _unitOfWork.Repository<module_category>().Delete(entity);
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
