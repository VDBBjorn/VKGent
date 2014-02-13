using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace p2g33_web.Models.ViewModels
{
    public class IntroductionViewModel
    {

        public IntroductionViewModel()
        {
            
        }

        [Required(ErrorMessage = "{0} is verplicht")]
        [DisplayName("Voornaam")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "{0} is verplicht")]
        [DisplayName("Achternaam")]
        public string LastName{ get; set; }
        [Required(ErrorMessage = "{0} is verplicht")]
        [DisplayName("E-mailadres")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Geen geldig e-mailadres")]
        public string Email{ get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [DisplayName("Reden voor het downloaden van ons pakket:")]
        public string DownloadReason { get; set; }

        [Required(ErrorMessage = "Type cursist is verplicht in te vullen")]
        [DisplayName("Ik ben")]
        public string CursistType { get; set; }

    }


    
}
