using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Interfaces;

namespace MoveInn.BAL.Models
{
    public partial class ProfileSetting
    {
        public int ID { get; set; }
        public int ProfileID { get; set; }
        public int SettingID { get; set; }
        public string SettingValue { get; set; }
    }
}
