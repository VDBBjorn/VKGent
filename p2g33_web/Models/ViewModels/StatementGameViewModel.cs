using System.ComponentModel.DataAnnotations;
using p2g33_web.Models.Domain;

namespace p2g33_web.Models.ViewModels
{
    public class StatementGameViewModel
    {
        public StatementGameViewModel(){}

        public StatementGameViewModel(StatementGame statementGame, LearningProcess learningProcess)
        {
            Title = statementGame.title;
            Description = statementGame.description;
            StatementGameQuestion = new StatementGameQuestionViewModel(statementGame.StatementGameQuestions[0]);
            LearningProcessCode = learningProcess.learningProcessCode;
            ElementId = statementGame.elementId;
            NumberOfQuestions = statementGame.StatementGameQuestions.Count;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public StatementGameQuestionViewModel StatementGameQuestion { get; set; }
        public string LearningProcessCode { get; set; }
        public int ElementId { get; set; }
        public int NumberOfQuestions { get; set; }
        [Range(1,1000000,ErrorMessage = "Gelieve een antwoord te kiezen om verder te kunnen gaan")]
        public int AnswerId { get; set; }
    }
}