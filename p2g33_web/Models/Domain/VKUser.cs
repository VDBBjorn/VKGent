using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace p2g33_web.Models.Domain
{
    public class VKUser
    {
        public VKUser()
        {
            LearningProcesses = new List<LearningProcess>();
            Evaluations = new List<Evaluation>();
            UserAnswers = new List<UserAnswer>();
            LearningProcesses = new List<LearningProcess>();
            LearningProcessesExternal = new List<LearningProcess>();
            LearningProcessesExternal = new List<LearningProcess>();
        }

        public string email { get; set; }
        public bool internalUser { get; set; }
        public bool guest { get; set; }
        public DateTime? creationDate { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public virtual ICollection<LearningProcess> LearningProcesses { get; set; }
        public virtual ICollection<LearningProcess> LearningProcessesExternal { get; set; }
        public virtual ICollection<LearningProcess> LearningProcessesCreator { get; set; }
        public virtual ICollection<Evaluation> Evaluations { get; set; } 
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }

        public IEnumerable<LearningProcess> GetAllLearningProcesses()
        {
            ICollection<LearningProcess> lp = LearningProcesses.ToList();
            foreach (var learningProcess in LearningProcessesExternal)
            {
                lp.Add(learningProcess);
            }
            foreach (var learningProcess in LearningProcessesCreator)
            {
                lp.Add(learningProcess);
            }
            return lp;
        }

        internal LearningProcess GetLearningProcess(string id)
        {
            foreach (var lp in LearningProcesses.Where(lp => lp.learningProcessCode.Equals(id)))
            {
                return lp;
            }
            foreach (var lp in LearningProcessesExternal.Where(lp => lp.learningProcessCode.Equals(id)))
            {
                return lp;
            }
            return LearningProcessesCreator.FirstOrDefault(lp => lp.learningProcessCode.Equals(id));
        }

        public bool CheckPlayed(int elementid, string learningProcessCode)
        {
            return UserAnswers.Any(userAnswer => userAnswer.ElementId == elementid && userAnswer.LearningProcessCode == learningProcessCode);
        }

        public void AnswerStatementGameQuestion(string learningProcessCode, int answerId, int statementGameQuestionId, int elementId)
        {
            UserAnswers.Add(new StatementGameUserAnswer
            {
                LearningProcessCode = learningProcessCode,
                Email = this.email,
                StatementGameAnswerId = answerId,
                StatementGameQuestionId = statementGameQuestionId,
                ElementId = elementId
            });
        }

        public void AnswerCaseQuestion(string learningProcessCode, int answerId, int caseQuestionId, int elementId)
        {
            UserAnswers.Add(new CaseUserAnswer
            {
                LearningProcessCode = learningProcessCode,
                Email = this.email,
                CaseQuestionId = caseQuestionId,
                CaseAnswerId = answerId,
                ElementId = elementId
            });
        }

        public void AnswerBoxQuestion(string learningProcessCode, string answerImageUrl, int boxQuestionId,
                                      int elementId, string motivation)
        {
            //BoxUserAnswer existingBoxUserAnswer = null;
            //foreach (BoxUserAnswer boxUserAnswer in UserAnswers.OfType<BoxUserAnswer>())
            //{
            //    if (boxUserAnswer.ElementId == elementId && boxUserAnswer.Email == this.email)
            //    {
            //        existingBoxUserAnswer = boxUserAnswer;
            //    }
            //}
            //if (existingBoxUserAnswer != null)
            //{
            //    UserAnswers.Remove(existingBoxUserAnswer);

            //    UserAnswers.Add(new BoxUserAnswer
            //    {
            //        UserAnswerId = existingBoxUserAnswer.UserAnswerId,
            //        LearningProcessCode = learningProcessCode,
            //        Email = this.email,
            //        BoxQuestionId = boxQuestionId,
            //        BoxAnswer = answerImageUrl,
            //        ElementId = elementId
            //    });
            //}
            //else
            //{
            UserAnswers.Add(new BoxUserAnswer
            {
                LearningProcessCode = learningProcessCode,
                Email = this.email,
                BoxQuestionId = boxQuestionId,
                BoxAnswer = answerImageUrl,
                ElementId = elementId,
                BoxMotivation = motivation
            });
            //}
        }

        public IEnumerable<E> GetUserAnswers<E>() where E : UserAnswer
        {
            return UserAnswers.OfType<E>();
        }

        public bool CheckEvaluationForm(string learningProcessCode)
        {
            return Evaluations.Any(p => p.Email.Equals(this.email) && p.LearningProcessCode.Equals(learningProcessCode));
        }
    }
}
