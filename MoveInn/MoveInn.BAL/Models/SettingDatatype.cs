using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Interfaces;

namespace MoveInn.BAL.Models
{
    public partial class SettingDatatype : IAuditable
    {
        public int ID { get; set; }
        public string DataTypeName { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
