using System.Collections.Generic;
using System.Collections.ObjectModel;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.ViewModels
{
    public class EndOfStatementGameViewModel
    {
        public EndOfStatementGameViewModel(){}

        public EndOfStatementGameViewModel(VKUser user,LearningProcess learningProcess,StatementGame statementGame)
        {
            Title = statementGame.title;
            Questions = new List<string>();
            foreach (var q in user.GetUserAnswers<StatementGameUserAnswer>())
            {
                Questions.Add(q.StatementGameQuestion.question);
            }
            Answers = new List<string>();
            foreach (var a in user.GetUserAnswers<StatementGameUserAnswer>())
            {
                Answers.Add(a.StatementGameAnswer.answer);
            }
            LearningProcessCode = learningProcess.learningProcessCode;
        }

        public string Title { get; set; }
        public IList<string> Questions { get; set; }
        public IList<string> Answers { get; set; }
        public string LearningProcessCode { get; set; }
    }
}