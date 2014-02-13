using p2g33_web.Models.Domain;

namespace p2g33_web.Models.ViewModels
{
    public class StatementGameAnswerViewModel
    {
        public StatementGameAnswerViewModel()
        {
            
        }
        public StatementGameAnswerViewModel(StatementGameAnswer answer)
        {
            AnswerId = answer.statementGameAnswerId;
            Answer = answer.answer;
        }

        public int AnswerId { get; set; }
        public string Answer { get; set; }
    }
}