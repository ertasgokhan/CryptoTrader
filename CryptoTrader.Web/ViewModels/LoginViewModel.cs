using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTrader.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-Mail is required")]
        [Display(Name = "E-Mail")]
        [EmailAddress(ErrorMessage = "E-Mail is not valid format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        public bool RememberMe { get; set; }
    }
}
