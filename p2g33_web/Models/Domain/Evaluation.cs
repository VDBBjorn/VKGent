using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2g33_web.Models.ViewModels;

namespace p2g33_web.Models.Domain
{
    public class Evaluation
    {
        public int EvaluationId { get; set; }
        public string Email { get; set; }
        public string LearningProcessCode { get; set; }
        public int BackgroundInformation { get; set; }
        public int UsefulBackgroundInformation { get; set; }
        public int PracticeExamples { get; set; }
        public int UsefulPracticeExamples { get; set; }
        public int ContentExpectation { get; set; }
        public int PreperationLearningPlatform { get; set; }
        public int PresentationLearningPlatform { get; set; }
        public int ContentLearningPlatform { get; set; }
        public int UsefulLearningPlatform { get; set; }
        public int ClearInformation { get; set; }
        public int ClearPresentation { get; set; }
        public int QuestionsMentor { get; set; }
        public int FormationManner { get; set; }
        public string RemarksFormation { get; set; }
        public string RemarksLearningPlatform { get; set; }
        public string RemarksMentor { get; set; }
        public string GeneralRemark { get; set; }
        public string MissedInFormation { get; set; }

        public Evaluation()
        {
            
        }

        public Evaluation(EvaluationFormViewModel model,string email)
        {
            Email = email;
            LearningProcessCode = model.LearningProcessCode;
            BackgroundInformation = model.BackgroundInformation;
            UsefulBackgroundInformation = model.UsefulBackgroundInformation;
            PracticeExamples = model.PracticeExamples;
            UsefulPracticeExamples = model.UsefulPracticeExamples;
            ContentExpectation = model.ContentExpectation;
            PreperationLearningPlatform = model.PreperationLearningPlatform;
            PresentationLearningPlatform = model.PresentationLearningPlatform;
            ContentLearningPlatform = model.ContentLearningPlatform;
            UsefulLearningPlatform = model.UsefulLearningPlatform;
            ClearInformation = model.ClearInformation;
            ClearPresentation = model.ClearPresentation;
            QuestionsMentor = model.QuestionsMentor;
            FormationManner = model.FormationManner;
            RemarksFormation = model.RemarksFormation;
            RemarksLearningPlatform = model.RemarksLearningPlatform;
            RemarksMentor = model.RemarksMentor;
            GeneralRemark = model.GeneralRemark;
            MissedInFormation = model.MissedInFormation;
        }
    }
}