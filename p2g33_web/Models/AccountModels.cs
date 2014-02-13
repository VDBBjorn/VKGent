using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace p2g33_web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "E-mailadres is verplicht ingevuld")]
        [Display(Name = "E-mailadres")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "{0} moet van formaat test@example.com zijn")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Wachtwoord moet worden ingevuld")]
        [DataType(DataType.Password)]
        [Display(Name = "Wachtwoord")]
        public string Password { get; set; }

        [Display(Name = "Onthouden?")]
        public bool RememberMe { get; set; }
    }
}
