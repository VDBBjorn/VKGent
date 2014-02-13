using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace p2g33_web.Models.Domain
{
    public abstract class Element
    {
        [Key]
        [Required]
        public int elementId { get; set; }
        public DateTime? availableFrom { get; set; }
        public DateTime? availableUntil { get; set; }
        [DisplayName("Omschrijving")]
        public string description { get; set; }
        public string keyWords { get; set; }
        public string targetGroup { get; set; }
        public string title { get; set; }
    }
}
