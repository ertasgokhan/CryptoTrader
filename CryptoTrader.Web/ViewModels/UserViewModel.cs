using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTrader.Web.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "User name is required")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "E-Mail is required")]
        [Display(Name = "E-Mail")]
        [EmailAddress(ErrorMessage = "E-Mail is not valid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Display(Name = "Confirm PassWord")]
        [DataType(DataType.Password)]
        [Compare("PassWord", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassWord { get; set; }

        [Required(ErrorMessage = "Cover Register Checkbox is required")]
        [Display(Name = "CoverRegisterCheckbox ")]
        public bool CoverRegisterCheckbox { get; set; }
    }
}
