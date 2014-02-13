using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using p2g33_web.Models.ViewModels;

namespace p2g33_web.Models.Domain
{
    public interface IVKUserRepository
    {
        IQueryable<VKUser> FindAll();
        VKUser FindBy(LoginModel model);
        VKUser FindBy(string p);
        void SaveChanges();
        void AnswerStatementGameQuestion(VKUser user, string learningProcessCode, int answerId, int statementGameQuestionId, int elementId);
        void AnswerCaseQuestion(VKUser user, string learningProcessCode, int answerId, int caseQuestionId, int elementId);
        void AnswerBoxQuestion(VKUser user, string learningProcessCode, string answerImageUrl, int boxQuestionId, int elementId, string motivation);
        void CreateTrialUser(IntroductionViewModel model);
    }
}