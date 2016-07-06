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
    public class SettingDatatypeService : BusinessService<setting_datatype>, ISettingDatatypeService
    {
        public SettingDatatypeService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
           _unitOfWork = unitOfWork;
           Mapper.CreateMap<setting_datatype, SettingDatatype>();
        }

        public SettingDatatypeService()
            : base(new UnitOfWork())
        {
            Mapper.CreateMap<setting_datatype, SettingDatatype>();
        }

        public SettingDatatype FindByID(int ID)
        {
            var predicate = PredicateBuilder.True<setting_datatype>();
            predicate = predicate.Or(p => p.ID == ID);
            var data = _unitOfWork.Repository<setting_datatype>().FindBy(predicate).FirstOrDefault();
            return Mapper.Map<setting_datatype, SettingDatatype>(data);
        }

        public new IEnumerable<SettingDatatype> GetAll()
        {
            var data = _unitOfWork.Repository<setting_datatype>().GetAll();
            return data.Select(p => Mapper.Map<setting_datatype, SettingDatatype>(p));
        }

        public virtual bool Create(SettingDatatype Model)
        {
            try
            {
                if (Model == null)
                {
                    throw new ArgumentNullException("entity");
                }
                var entity = Mapper.Map<SettingDatatype, setting_datatype>(Model);
                _unitOfWork.Repository<setting_datatype>().Add(entity);
                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Update(SettingDatatype Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<SettingDatatype, setting_datatype>(Model);
                _unitOfWork.Repository<setting_datatype>().Edit(entity);
                _unitOfWork.Commit();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        public virtual bool Delete(SettingDatatype Model)
        {
            try
            {
                if (Model == null) throw new ArgumentNullException("entity");
                var entity = Mapper.Map<SettingDatatype, setting_datatype>(Model);
                _unitOfWork.Repository<setting_datatype>().Delete(entity);
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
