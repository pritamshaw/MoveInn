using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Interfaces;

namespace MoveInn.BAL.Models
{
    public partial class EventSetting : IAuditable
    {
        public int RowID { get; set; }
        public System.Guid ID { get; set; }
        public int EventID { get; set; }
        public int SettingID { get; set; }
        public string SettingValue { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
