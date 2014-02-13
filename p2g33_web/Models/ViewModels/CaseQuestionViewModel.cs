using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.ViewModels
{
    public class CaseQuestionViewModel
    {
        public CaseQuestionViewModel()
        {
            
        }
        
        public CaseQuestionViewModel(CaseQuestion question)
        {
            QuestionId = question.caseQuestionId;
            Question = question.question;
            Answers = new List<CaseAnswerViewModel>();
            foreach (var answer in question.CaseAnswers)
            {
                Answers.Add(new CaseAnswerViewModel(answer));
            }
            Consideration = question.consideration;
        }
        public int QuestionId { get; set; }
        public string Question { get; set; }
        public IList<CaseAnswerViewModel> Answers { get; set; }
        public string Consideration { get; set; }

        public CaseAnswerViewModel GetAnswerById(int id)
        {
            return Answers.FirstOrDefault(answer => answer.AnswerId == id);
        }
    }
}