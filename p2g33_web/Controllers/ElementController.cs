using System;
using System.Collections.Generic;
using System.Web.Mvc;
using p2g33_web.Models.Domain;
using p2g33_web.Models.ViewModels;

namespace p2g33_web.Controllers
{
    [Authorize]
    public class ElementController : Controller
    {
        private IVKUserRepository UserRepository;
        private Element _element;

        public ElementController(IVKUserRepository userRepository)
        {
            this.UserRepository = userRepository;
        }

        public ActionResult PlayStatementGame(DetailsStatementGameViewModel model, VKUser user)
        {
            var learningProcess = user.GetLearningProcess(model.LearningProcessCode);
            var statementGame = learningProcess.GetElementByType<StatementGame>(model.ElementId);

            Session["QuestionIndex"] = 0;

            if (user.internalUser)
                TempData["Info"] = "Uw resultaten worden niet opgeslagen, omdat u een interne medewerker bent!";
            if (user.CheckPlayed(model.ElementId, learningProcess.learningProcessCode))
                TempData["Info"] = "U heeft dit stellingenspel reeds gespeeld, uw antwoorden worden dit keer niet meer opgeslagen";

            return View(new StatementGameViewModel(statementGame,learningProcess));
        }

        [HttpPost]
        public ActionResult SaveStatementGame(StatementGameViewModel model, VKUser user)
        {
            var learningProcess = user.GetLearningProcess(model.LearningProcessCode);
            var statementGame = learningProcess.GetElementByType<StatementGame>(model.ElementId);
            var questionIndex = (int)Session["QuestionIndex"];

            if (model.AnswerId != 0)
            {

                if (!user.internalUser)
                {
                    if (user.CheckPlayed(model.ElementId, model.LearningProcessCode) == false)
                        UserRepository.AnswerStatementGameQuestion(user, model.LearningProcessCode, model.AnswerId,
                            statementGame.StatementGameQuestions[questionIndex].statementGameQuestionId, model.ElementId);
                }

                var nextQuestionIndex = (int) Session["QuestionIndex"] + 1;
                if (nextQuestionIndex >= statementGame.StatementGameQuestions.Count)
                {
                    TempData["Succes"] = "Stellingenspel werd succesvol afgerond!";
                    if (user.internalUser)
                    {
                        return RedirectToAction("DetailsLearningProcess", "LearningProcesses",
                                                new {id = learningProcess.learningProcessCode});
                    }
                    return View("EndOfStatementGame", new EndOfStatementGameViewModel(user, learningProcess,statementGame));
                }

                model.StatementGameQuestion =
                    new StatementGameQuestionViewModel(statementGame.StatementGameQuestions[nextQuestionIndex]);
                model.AnswerId = 1;
                Session["QuestionIndex"] = nextQuestionIndex;
                return View("PlayStatementGame", model);
            }
            model.StatementGameQuestion = new StatementGameQuestionViewModel(statementGame.StatementGameQuestions[questionIndex]);
            return View("PlayStatementGame",model);
        }

        [HttpPost]
        public ActionResult PlayCase(DetailsCaseViewModel model,VKUser user)
        {
            var learningProcess = user.GetLearningProcess(model.LearningProcessCode);
            var thiscase = learningProcess.GetElementByType<Case>(model.ElementId);

            if (user.internalUser)
                TempData["Info"] = "Uw resultaten worden niet opgeslagen, omdat u een interne medewerker bent!";
            if (user.CheckPlayed(model.ElementId, model.LearningProcessCode))
                TempData["Info"] = "U heeft deze casus reeds gespeeld, uw antwoorden worden dit keer niet meer opgeslagen";
            
            return View(new CaseViewModel(thiscase, learningProcess));
        }

        [HttpPost]
        public ActionResult SaveFirstCase(CaseViewModel model, VKUser user)
        {
            var learningProcess = user.GetLearningProcess(model.LearningProcessCode);
            var acase = learningProcess.GetElementByType<Case>(model.ElementId);

            if (model.AnswerId != 0)
            {
                model.Question = new CaseQuestionViewModel(acase.caseQuestion);
                var answer = acase.caseQuestion.getAnswerById(model.AnswerId);
                if (answer != null)
                {
                    Session["QuestionId"] = acase.caseQuestion.caseQuestionId;
                    if (HttpContext.Request.IsAjaxRequest())
                    {
                        if (!user.internalUser)
                        {
                            if (user.CheckPlayed(model.ElementId, model.LearningProcessCode) == false)
                                UserRepository.AnswerCaseQuestion(user, model.LearningProcessCode, model.AnswerId,
                                                                  acase.caseQuestion.caseQuestionId, model.ElementId);
                        }
                        model.Feedback = answer.feedback;
                        if (model.Feedback != null)
                            return PartialView("FeedbackCase", model);
                        model.Feedback = "Voor deze vraag is er geen feedback";
                        return PartialView("FeedbackCase", model);
                    }
                }
                else
                {
                    return View("Error");
                }
            }
            model.Question = new CaseQuestionViewModel(acase.caseQuestion);
            return View("PlayCase", model);
        }

        [HttpPost]
        public ActionResult PlayRestCase(CaseViewModel model, VKUser user)
        {
            var learningProcess = user.GetLearningProcess(model.LearningProcessCode);
            var acase = learningProcess.GetElementByType<Case>(model.ElementId);

            if (model.AnswerId != 0)
            {
                var question = acase.GetQuestion((int) Session["QuestionId"]);
                var answer = question.getAnswerById(model.AnswerId);
                if (HttpContext.Request.IsAjaxRequest())
                {
                    model.Question = new CaseQuestionViewModel(question);
                    model.Feedback = answer.feedback;
                    if(model.Feedback!=null)
                        return PartialView("FeedbackRestCase", model);
                    model.Feedback = "Voor deze vraag is er geen feedback";
                    return PartialView("FeedbackRestCase", model);
                }
                if (answer.nextQuestion != null)
                {
                    var nextQuestion = answer.nextQuestion;
                    model.Question = new CaseQuestionViewModel(nextQuestion);
                    Session["QuestionId"] = model.Question.QuestionId;
                    return View("PlayRestCase", model);
                }
                return View("EndOfCase",model);
            }
            var q = acase.GetQuestion((int) Session["QuestionId"]);
            model.Question = new CaseQuestionViewModel(q);
            return View("PlayRestCase", model);
        }

        [HttpPost]
        public ActionResult PlayBox(DetailsBoxViewModel model, VKUser user)
        {
            var learningProcess = user.GetLearningProcess(model.LearningProcessCode);
            var box = learningProcess.GetElementByType<Box>(model.ElementId);
            var boxmodel = new BoxViewModel(box, learningProcess);
            Session["ImageUrlsRemaining"] = boxmodel.ImageUrlsRemaining;
            Session["ImageUrlsChosen"] = boxmodel.ImageUrlsChosen;
            if (user.CheckPlayed(model.ElementId, model.LearningProcessCode))
            {
                TempData["Info"] =
                    "U heeft dit spel al gespeeld. De antwoorden die u nu geeft zullen de vorige antwoorden overschrijven.";
            }
            if (user.internalUser)
            {
                TempData["Info"] = "Uw resultaten worden niet opgeslagen, omdat u een interne medewerker bent!";
            }
            return View(boxmodel);
        }

        [HttpPost]
        public ActionResult SaveBoxQuestion(BoxViewModel model, VKUser user)
        {
            var learningProcess = user.GetLearningProcess(model.LearningProcessCode);
            var box = learningProcess.GetElementByType<Box>(model.ElementId);
            model.ImageUrlsRemaining = (List<String>)Session["ImageUrlsRemaining"];
            model.ImageUrlsChosen = (List<String>) Session["ImageUrlsChosen"];
            if (model.Motivation !=null && model.ChosenImageUrl !=null)
            {
                model.ImageUrlsChosen.Add(model.ChosenImageUrl);
                model.ImageUrlsRemaining.Remove(model.ChosenImageUrl);
                Session["ImageUrlsRemaining"] = model.ImageUrlsRemaining;
                Session["ImageUrlsChosen"] = model.ImageUrlsChosen;

                if (!user.internalUser)
                {
                    UserRepository.AnswerBoxQuestion(user, model.LearningProcessCode, model.ChosenImageUrl,
                                                     box.questions[model.CurrentQuestionIndex].boxQuestionId,
                                                     box.elementId, model.Motivation);

                }
                model.CurrentQuestionIndex++;
                if (box.questions.Count <= model.CurrentQuestionIndex || model.ImageUrlsRemaining == null)
                {
                    TempData["Succes"] = "Doos werd succesvol afgerond!";
                    return View("EndBox", new EndOfBoxViewModel(user, learningProcess, box));
                }
                model.Question = box.questions[model.CurrentQuestionIndex].question;
                model.Motivation = null;
                ModelState.Clear();
                return View("PlayBox", model);
            }
            return View("PlayBox", model);
        }

        public ActionResult ViewDocument(int elementId, string learningProcessCode, VKUser user)
        {
            var learningProcess = user.GetLearningProcess(learningProcessCode);
            var document = learningProcess.GetElementByType<Document>(elementId);

            if (document.fileLocation.EndsWith(".pdf"))
            {
                Session["format"] = "pdf";
            } else if (document.fileLocation.EndsWith(".mp4"))
            {
                Session["format"] = "video";
            }
            else
            {
                Session["format"] = "other";
            }

            return View("ViewDocument", new DocumentViewModel(document, learningProcess));
        }
    }
}