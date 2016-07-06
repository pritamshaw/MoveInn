using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Interfaces;

namespace MoveInn.BAL.Models
{
    public partial class Post : IAuditable
    {
        public int RowID { get; set; }
        public System.Guid ID { get; set; }
        public int ProfileID { get; set; }
        public string Title { get; set; }
        public string PostContent { get; set; }
        public bool IsPublished { get; set; }
        public bool IsCommentEnabled { get; set; }
        public int Raters { get; set; }
        public float Rating { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
