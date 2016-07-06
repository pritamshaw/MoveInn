using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Interfaces;

namespace MoveInn.BAL.Models
{
    public partial class UserSetting
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int SettingID { get; set; }
        public string SettingValue { get; set; }
    }
}
