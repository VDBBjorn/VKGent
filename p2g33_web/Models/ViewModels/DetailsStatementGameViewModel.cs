using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.ViewModels
{
    public class DetailsStatementGameViewModel
    {
        public DetailsStatementGameViewModel()
        {
            
        }

        public DetailsStatementGameViewModel(StatementGame statementGame, LearningProcess learningProcess, VKUser user)
        {
            LearningProcessCode = learningProcess.learningProcessCode;
            ElementId = statementGame.elementId;
            Title = statementGame.title;
            Description = statementGame.description;
            AvailableFrom = DateTime.Parse(statementGame.availableFrom.ToString()).ToShortDateString();
            AvailableUntil = DateTime.Parse(statementGame.availableUntil.ToString()).ToShortDateString();
            Status = user.CheckPlayed(statementGame.elementId, learningProcess.learningProcessCode) ? "Reeds gespeeld" : "Nog niet gespeeld";
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
        [DisplayName("Status")]
        public string Status { get; set; }
    }
}