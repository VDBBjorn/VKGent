using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using p2g33_web.Models.Domain;
using p2g33_web.Models.ViewModels;

namespace p2g33_web.Models.DAL
{
    public class VKUserRepository : IVKUserRepository
    {
        private readonly P2G33Context _context;
        private readonly DbSet<VKUser> _users;

        public VKUserRepository(P2G33Context p2G33Context)
        {
            this._context = p2G33Context;
            _users = _context.VKUsers;
        }

        public IQueryable<VKUser> FindAll()
        {
            return _users.OrderBy(p => p.lastName);
        }

        public VKUser FindBy(LoginModel model)
        {
            return _users.SingleOrDefault(p => (p.email.Equals(model.UserName)) && (p.password.Equals(model.Password)));
        }

        public VKUser FindBy(String userName)
        {
            return _users.SingleOrDefault(p => p.email.Equals(userName));
        }

        public void AnswerStatementGameQuestion(VKUser user, string learningProcessCode, int answerId, int statementGameQuestionId, int elementId)
        {
            var updateuser = _users.FirstOrDefault(p => (p.email.Equals(user.email)));
            if (updateuser != null)
                updateuser.AnswerStatementGameQuestion(learningProcessCode, answerId, statementGameQuestionId, elementId);
            SaveChanges();
        }

        public void AnswerCaseQuestion(VKUser user, string learningProcessCode, int answerId, int caseQuestionId, int elementId)
        {
            var updateuser = _users.FirstOrDefault(p => (p.email.Equals(user.email)));
            if (updateuser != null)
                updateuser.AnswerCaseQuestion(learningProcessCode, answerId, caseQuestionId, elementId);
            SaveChanges();
        }
        
        public void AnswerBoxQuestion(VKUser user, string learningProcessCode, string answerImageUrl, int boxQuestionId, int elementId, string motivation)
        {
            var updateuser = _users.FirstOrDefault(p => (p.email.Equals(user.email)));
            if (updateuser != null)
            {
                BoxUserAnswer existingAnswer = null;
                foreach (BoxUserAnswer boxUserAnswer in updateuser.UserAnswers.OfType<BoxUserAnswer>())
                {
                    if (boxUserAnswer.LearningProcessCode == learningProcessCode && boxUserAnswer.ElementId == elementId
                        && boxUserAnswer.BoxQuestionId == boxQuestionId)
                        existingAnswer = boxUserAnswer;
                }
                if (existingAnswer==null)
                {
                    updateuser.AnswerBoxQuestion(learningProcessCode, answerImageUrl, boxQuestionId, elementId, motivation);
                }
                else
                {
                    _context.UpdateBoxUserAnswer(user.email, learningProcessCode, elementId, boxQuestionId, answerImageUrl, motivation);
                }
                
            }
            SaveChanges();
        }

        public void CreateTrialUser(IntroductionViewModel model)
        {
            var trialUser = new VKUser
            {
                email = model.Email,
                password = "trial",
                internalUser = false,
                firstName = model.FirstName,
                lastName = model.LastName,
                guest = true,
                creationDate = DateTime.Now
            };
            if (_users.FirstOrDefault(p => p.email.Equals(model.Email)) == null)
            {
                _users.Add(trialUser);
                SaveChanges();
            }
        }

        public void SaveChanges()
        {
            //try
            //{
            _context.SaveChanges();
            //}
            //catch (DbEntityValidationException ex)
            //{
            //    foreach (var valError in ex.EntityValidationErrors)
            //    {
            //        foreach (var error in valError.ValidationErrors)
            //        {
            //            Trace.WriteLine(error.ErrorMessage);
            //        }

            //    }
            //}
        }
    }
}