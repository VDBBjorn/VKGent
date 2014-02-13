using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.ViewModels
{
    public class EndOfBoxViewModel
    {
        public EndOfBoxViewModel(){}

        public EndOfBoxViewModel(VKUser user,LearningProcess learningProcess,Box box )
        {
            Title = box.title;
            Questions = new List<string>();
            foreach (var q in user.GetUserAnswers<BoxUserAnswer>())
            {
                Questions.Add(q.BoxQuestion.question);
            }
            Answers = new List<string>();
            foreach (var a in user.GetUserAnswers<BoxUserAnswer>())
            {
                Answers.Add(a.BoxMotivation);
            }
            Images = new List<string>();
            foreach (var a in user.GetUserAnswers<BoxUserAnswer>())
            {
                Images.Add(a.BoxAnswer);
            }

            Description = box.description;
            LearningProcessCode = learningProcess.learningProcessCode;
        }

        public string Title { get; set; }
        [DisplayName("Vraag:")]
        public IList<string> Questions { get; set; }
        [DisplayName("Motivatie:")]
        public IList<string> Answers { get; set; }
        public IList<string> Images { get; set; } 
        public string LearningProcessCode { get; set; }
        public string Description { get; set; }
    }
}
