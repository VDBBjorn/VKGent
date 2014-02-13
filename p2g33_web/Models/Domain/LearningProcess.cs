using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace p2g33_web.Models.Domain
{
    public class LearningProcess
    {
        public LearningProcess()
        {
            this.Elements = new List<Element>();

        }
        
        public string learningProcessCode { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Beschikbaar vanaf")]
        public DateTime? availableFrom { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Beschikbaar tot")]
        public DateTime? availableUntil { get; set; }
        [DisplayName("Omschrijving")]
        public string description { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Live datum")]
        public DateTime? startDateLife { get; set; }
        [DisplayName("Doelgroep")]
        public string targetGroup { get; set; }
        [DisplayName("Titel")]
        public string title { get; set; }
        [DisplayName("Eigenaar")]
        public VKUser creator { get; set; }
        public virtual ICollection<Element> Elements { get; set; }

        public Element GetElement(int id)
        {
            return Elements.FirstOrDefault(element => element.elementId.Equals(id));
        }

        public E GetElementByType<E>(int id) where E : Element
        {
            return Elements.OfType<E>().FirstOrDefault(element => element.elementId.Equals(id));
        }

        public IEnumerable<E> GetElements<E>() where E : Element
        {
            return
                Elements.OfType<E>()
                        .Where(
                            element => (element.availableFrom < DateTime.Now) && (element.availableUntil > DateTime.Now))
                        .ToList();
        }
    }
}
