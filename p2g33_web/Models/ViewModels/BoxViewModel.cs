using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.ViewModels
{
    public class BoxViewModel
    {
        public BoxViewModel()
        {
            
        }
        public BoxViewModel(Box box, LearningProcess learningProcess)
        {
            Title = box.title;
            Description = box.description;
            Theme = box.theme;
            LearningProcessCode = learningProcess.learningProcessCode;
            ElementId = box.elementId;
            CurrentQuestionIndex = 0;
            ImageUrlsRemaining = new List<string>();
            for (int i = 1; i <= 5; i++)
            {
                ImageUrlsRemaining.Add("/Images/BoxImages/img"+i+".png");
            }
            ImageUrlsChosen = new List<string>();
            NumberOfQuestions = box.questions.Count;
            Motivation = null;
            Question = box.questions[0].question;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Theme { get; set; }
        public string LearningProcessCode { get; set; }
        public int ElementId { get; set; }
        public string Question { get; set; }
        public int NumberOfQuestions { get; set; }
        public int CurrentQuestionIndex { get; set; }
        public IList<string> ImageUrlsRemaining { get; set; }
        public IList<string> ImageUrlsChosen { get; set; }
        [Required(ErrorMessage = "Kies een afbeelding")]
        public string ChosenImageUrl { get; set; }
        [Required(ErrorMessage = "U moet een motivatie invullen")]
        [DisplayName("Motivatie:")]
        public string Motivation { get; set; }
  
        
    }
}