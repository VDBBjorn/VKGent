using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.ViewModels
{
    public class DetailsBoxViewModel
    {
        public DetailsBoxViewModel()
        {
            
        }
        public DetailsBoxViewModel(Box box, LearningProcess learningProcess, VKUser user)
        {
            LearningProcessCode = learningProcess.learningProcessCode;
            ElementId = box.elementId;
            Title = box.title;
            Description = box.description;
            AvailableFrom = DateTime.Parse(box.availableFrom.ToString()).ToShortDateString();
            AvailableUntil = DateTime.Parse(box.availableUntil.ToString()).ToShortDateString();
            Theme = box.theme;
            Status = user.CheckPlayed(box.elementId, learningProcess.learningProcessCode) ? "Reeds gespeeld" : "Nog niet gespeeld";
        }

        public string LearningProcessCode { get; set; }
        public int ElementId { get; set; }
        [DisplayName("Titel")]
        public string Title { get; set; }
        [DisplayName("Omschrijving")]
        public string Description { get; set; }
        [DisplayName("Beschikbaar vanaf")]
        public string AvailableFrom { get; set; }
        [DisplayName("Beschikbaar tot")]
        public string AvailableUntil { get; set; }
        [DisplayName("Thema")]
        public string Theme { get; set; }
        [DisplayName("Status")]
        public string Status { get; set; }
    }
}