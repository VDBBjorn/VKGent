using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.ViewModels
{
    public class DocumentViewModel
    {
        public DocumentViewModel()
        {
            
        }

        public DocumentViewModel(Document document, LearningProcess learningProcess)
        {
            ElementId = document.elementId;
            FileLocation = document.fileLocation;
            LearningProcessCode = learningProcess.learningProcessCode;
            Title = document.title;
            Description = document.description;
            AvailableFrom = DateTime.Parse(document.availableFrom.ToString()).ToShortDateString();
            AvailableUntil = DateTime.Parse(document.availableUntil.ToString()).ToShortDateString();
        }

        public int ElementId { get; set; }
        public string LearningProcessCode { get; set; }
        public string FileLocation { get; set; }
        [DisplayName("Titel")]
        public string Title { get; set; }
        [DisplayName("Omschrijving")]
        public string Description { get; set; }
        [DisplayName("Beschikbaar vanaf")]
        public string AvailableFrom { get; set; }
        [DisplayName("Beschikbaar tot")]
        public string AvailableUntil { get; set; }

    }
}