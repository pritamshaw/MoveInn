using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Interfaces;

namespace MoveInn.BAL.Models
{
    public partial class ProfileMember
    {
        public int ID { get; set; }
        public int ProfileID { get; set; }
        public int MemberID { get; set; }
        public string Description { get; set; }
        public DateTime RequestedDate { get; set; }
        public bool IsAccepted { get; set; }
        public DateTime AcceptedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
