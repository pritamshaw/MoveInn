using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoveInn.BAL.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MoveInn.BAL.Models
{
    public partial class UserLogin
    {
        [Required]
        [RegularExpression("[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,4}")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
