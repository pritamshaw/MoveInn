using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Interfaces;

namespace MoveInn.BAL.Models
{
    public partial class PostComment
    {
        public int RowID { get; set; }
        public System.Guid ID { get; set; }
        public int PostID { get; set; }
        public int ParentID { get; set; }
        public int ProfileID { get; set; }
        public DateTime CommentDate { get; set; }
        public string Author { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Comment { get; set; }
        public string Country { get; set; }
        public string IP { get; set; }
        public bool IsApproved { get; set; }
        public bool IsSpam { get; set; }
        public int Raters { get; set; }
        public float Rating { get; set; }
        public bool IsActive { get; set; }
    }
}
