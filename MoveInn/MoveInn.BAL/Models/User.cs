using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Interfaces;
using FluentValidation.Attributes;
using MoveInn.BAL.ModelValidators;

namespace MoveInn.BAL.Models
{
    [Validator(typeof(UserValidator))]
    public partial class User : IAuditable
    {
        public int RowID { get; set; }
        public System.Guid? ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string Zip { get; set; }
        public DateTime? BirthDate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime? AgreedToTermsDate { get; set; }
        public DateTime? LastLogonTime { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
