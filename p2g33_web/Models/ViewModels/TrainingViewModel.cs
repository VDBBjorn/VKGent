using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace p2g33_web.Models.ViewModels
{
    public class TrainingViewModel
    {
        public TrainingViewModel()
        {
            
        }

        [Required(ErrorMessage = "{0} is verplicht")]
        [DisplayName("Voornaam contactpersoon")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} is verplicht")]
        [DisplayName("Achternaam contactpersson")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "{0} is verplicht")]
        [DisplayName("Dienst")]
        public string Service { get; set; }
        [Required(ErrorMessage = "{0} is verplicht")]
        [RegularExpression(@"^\d{9,10}$", ErrorMessage = "Geef een geldig telefoonnummer (vast nummer van 9 cijfers of gsm-nummer van 10 cijfers) op")]
        [DisplayName("Telefoonnummer")]
        public int? Telephone { get; set; }
        [RegularExpression(@"^\d{9}$",ErrorMessage = "Geef een geldig faxnummer (vast nummer van 9 cijfers) op")]
        [DisplayName("Fax (niet verplicht)")]
        public int? Fax { get; set; }
        [Required(ErrorMessage = "{0} is verplicht")]
        [DisplayName("E-mailadres")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage = "Geen geldig e-mailadres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [Range(1,1000000,ErrorMessage = "Minstens 1 persoon ingeven")]
        [DisplayName("Aantal personen")]
        public int? NumberOfPeople { get; set; }
        [Required(ErrorMessage = "{0} is verplicht")]
        [DisplayName("Voor wie?")]
        public string TargetGroup { get; set; }
        [Required(ErrorMessage = "{0} is verplicht")]
        [DisplayName("Doel van de vorming")]
        public string Objective { get; set; }
        [Required(ErrorMessage = "{0} is verplicht")]
        [DisplayName("Voorkennis over kindermishandeling")]
        public string PreviousKnowledge { get; set; }
        [Required(ErrorMessage = "{0} is verplicht")]
        [DisplayName("Prijs")]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Geef een geldig faxnummer (vast nummer van 9 cijfers) op")]
        [Range(100,200,ErrorMessage = "Geef minimum 100 en maximum 200 euro in")]
        public int? Price { get; set; }

    }
}