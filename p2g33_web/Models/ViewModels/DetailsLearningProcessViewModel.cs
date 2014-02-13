using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.ViewModels
{
    public class DetailsLearningProcessViewModel
    {
        public DetailsLearningProcessViewModel()
        {
            
        }

        public DetailsLearningProcessViewModel(LearningProcess learningProcess, VKUser user)
        {
            LearningProcessCode = learningProcess.learningProcessCode;
            Title = learningProcess.title;
            Description = learningProcess.description;
            AvailableFrom = DateTime.Parse(learningProcess.availableFrom.ToString()).ToShortDateString();
            AvailableUntil = DateTime.Parse(learningProcess.availableUntil.ToString()).ToShortDateString();
            StartDateLife = DateTime.Parse(learningProcess.startDateLife.ToString()).ToShortDateString();

            Documents = new List<Document>();
            foreach (var doc in learningProcess.GetElements<Document>())
            {
                Documents.Add(doc);
            }
            Cases = new List<Case>();
            foreach (var acase in learningProcess.GetElements<Case>())
            {
                Cases.Add(acase);
            }
            StatementGames = new List<StatementGame>();
            foreach (var sg in learningProcess.GetElements<StatementGame>())
            {
                StatementGames.Add(sg);
            }
            Boxes = new List<Box>();
            foreach (var box in learningProcess.GetElements<Box>())
            {
                Boxes.Add(box);
            }
            if (user.CheckEvaluationForm(learningProcess.learningProcessCode)==false && DateTime.Now > learningProcess.startDateLife)
            {
                EvaluationForm = true;
            }
            else
            {
                EvaluationForm = false;
            }
        }

        public string LearningProcessCode { get; set; }
        [DisplayName("Titel")]
        public string Title { get; set; }
        [DisplayName("Omschrijving")]
        public string Description { get; set; }
        [DisplayName("Beschikbaar vanaf")]
        public string AvailableFrom { get; set; }
        [DisplayName("Live datum")]
        public string StartDateLife { get; set; }
        [DisplayName("Beschikbaar tot")]
        public string AvailableUntil { get; set; }

        public ICollection<Document> Documents { get; set; }
        public ICollection<Case> Cases { get; set; }
        public ICollection<StatementGame> StatementGames { get; set; }
        public ICollection<Box> Boxes { get; set; }

        public bool EvaluationForm { get; set; }

    }
}