using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HR53.Core.ViewModels
{
    public class ResetPasswordViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You have to fill in the blanks")]
        [Display(Name = "Old Password: ")]
        [MinLength(6, ErrorMessage = "The password must be at least 6 charachter")]
        public string OldPassword { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "You have to fill in the blanks")]
        [Display(Name = "New Password: ")]
        public string NewPassword { get; set; }

        [Compare(nameof(NewPassword), ErrorMessage = "The passwords are not same")]
        [Required(ErrorMessage = "You have to fill in the blanks")]
        [Display(Name = "New password confirm: ")]
        [MinLength(6, ErrorMessage = "The password must be at least 6 charachter")]
        public string ConfirmNewPassword { get; set; }
    }
}
