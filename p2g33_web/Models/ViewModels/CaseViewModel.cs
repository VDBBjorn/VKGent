using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.ViewModels
{
    public class CaseViewModel
    {
        public CaseViewModel()
        {
            
        }
        
        public CaseViewModel(Case element,LearningProcess learningProcess)
        {
            LearningProcessCode = learningProcess.learningProcessCode;
            ElementId = element.elementId;
            Title = element.title;
            Description = element.description;
            Situation = element.situation;
            Question = new CaseQuestionViewModel(element.caseQuestion);
            MovieFilePath = element.movieFilePath;
        }

        public string LearningProcessCode { get; set; }
        public int ElementId { get; set; }
        public string Title { get; set; }
        [DisplayName("Omschrijving")]
        public string Description { get; set; }
        [DisplayName("Situatie")]
        public string Situation { get; set; }
        public CaseQuestionViewModel Question { get; set; }
        public string MovieFilePath { get; set; }
        [Range(1, 1000000, ErrorMessage = "Gelieve een antwoord te kiezen om verder te kunnen gaan")]
        public int AnswerId { get; set; }
        public string Feedback { get; set; }
    }
}