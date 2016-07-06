using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Interfaces;

namespace MoveInn.BAL.Models
{
    public partial class ProfileModule
    {
        public int ID { get; set; }
        public int ProfileID { get; set; }
        public int ModuleID { get; set; }
    }
}
