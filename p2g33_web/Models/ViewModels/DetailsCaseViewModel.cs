using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.ViewModels
{
    public class DetailsCaseViewModel
    {
        public DetailsCaseViewModel()
        {
            
        }

        public DetailsCaseViewModel(Case aCase, LearningProcess learningProcess, VKUser user)
        {
            LearningProcessCode = learningProcess.learningProcessCode;
            ElementId = aCase.elementId;
            Title = aCase.title;
            Description = aCase.description;
            AvailableFrom = DateTime.Parse(aCase.availableFrom.ToString()).ToShortDateString();
            AvailableUntil = DateTime.Parse(aCase.availableUntil.ToString()).ToShortDateString();
            Situation = aCase.situation;
            MovieFilePath = aCase.movieFilePath;
            Status = user.CheckPlayed(aCase.elementId, learningProcess.learningProcessCode) ? "Reeds gespeeld" : "Nog niet gespeeld";
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
        [DisplayName("Situatie")]
        public string Situation { get; set; }
        public string MovieFilePath { get; set; }
        [DisplayName("Status")]
        public string Status { get; set; }
    }
}