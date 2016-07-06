using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Models;
using MoveInn.DAL.EntityModel;

namespace MoveInn.BAL.Interfaces
{
    public interface ISettingDatatypeService : IBusinessService<setting_datatype>
    {
        SettingDatatype FindByID(int ID);
        new IEnumerable<SettingDatatype> GetAll();
        bool Create(SettingDatatype entity);
        bool Delete(SettingDatatype entity);
        bool Update(SettingDatatype entity);
    }
}
