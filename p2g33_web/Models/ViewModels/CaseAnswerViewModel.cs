using p2g33_web.Models.Domain;

namespace p2g33_web.Models.ViewModels
{
    public class CaseAnswerViewModel
    {
        public CaseAnswerViewModel()
        {

        }

        public CaseAnswerViewModel(CaseAnswer answer)
        {
            AnswerId = answer.caseAnswerId;
            Answer = answer.answer;
            FeedBack = answer.feedback;
            NextQuestion = answer.nextQuestion;
        }

        public int AnswerId { get; set; }
        public string Answer { get; set; }
        public string FeedBack { get; set; }
        public CaseQuestion NextQuestion { get; set; }
    }
}