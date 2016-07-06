using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Interfaces;

namespace MoveInn.BAL.Models
{
    public partial class PostNotify
    {
        public int PostNotifyID { get; set; }
        public int PostID { get; set; }
        public int ProfileID { get; set; }
        public string NotifyAddress { get; set; }
    }
}
