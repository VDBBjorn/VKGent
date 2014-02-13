using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.ViewModels
{
    public class StatementGameQuestionViewModel
    {
        public StatementGameQuestionViewModel()
        {
            
        }

        public StatementGameQuestionViewModel(StatementGameQuestion question)
        {
            QuestionId = question.statementGameQuestionId;
            Question = question.question;
            Answers = new List<StatementGameAnswerViewModel>();
            foreach (var answer in question.StatementGameQuestionAnswers)
            {
                Answers.Add(new StatementGameAnswerViewModel(answer));
            }
        }

        public int QuestionId { get; set; }
        public string Question { get; set; }
        public IList<StatementGameAnswerViewModel> Answers { get; set; }

        
    }
}