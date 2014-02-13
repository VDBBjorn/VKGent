using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using p2g33_web.Models.Domain;
using p2g33_web.Models.ViewModels;

namespace p2g33_web.Controllers
{
    [Authorize]
    public class LearningProcessesController : Controller
    {
        private IEnumerable<LearningProcess> _learningProcesses;
        private LearningProcess _learningProcess;
        private IEvaluationRepository evaluationRepository;
        private IVKUserRepository userRepository;
        private Evaluation evaluation;

        public LearningProcessesController(IEvaluationRepository evaluationRepository, IVKUserRepository userRepository)
        {
            this.evaluationRepository = evaluationRepository;
            this.userRepository = userRepository;
        }

        public ActionResult Index(VKUser user)
        {
            _learningProcesses = user.GetAllLearningProcesses().OrderBy(o => o.startDateLife);
            return View("Index", _learningProcesses);
        }

        public ActionResult DetailsLearningProcess(string id, VKUser user)
        {
            _learningProcess = user.GetLearningProcess(id);
            return _learningProcess == null ? View("Index") : View("DetailsLearningProcess",new DetailsLearningProcessViewModel(_learningProcess,user));
        }

        public ActionResult DetailsDocument(string lpid, int elementid, VKUser user)
        {
            _learningProcess = user.GetLearningProcess(lpid);
            var document = _learningProcess.GetElementByType<Document>(elementid);
            return View("DetailsDocument", new DocumentViewModel((Document) document, _learningProcess));
        }

        public ActionResult DetailsStatementGame(string lpid, int elementid, VKUser user)
        {
            _learningProcess = user.GetLearningProcess(lpid);
            var element = _learningProcess.GetElement(elementid);
            return View("DetailsStatementGame",
                        new DetailsStatementGameViewModel((StatementGame) element, _learningProcess,user));
        }

        public ActionResult DetailsBox(string lpid, int elementid, VKUser user)
        {
            _learningProcess = user.GetLearningProcess(lpid);
            var element = _learningProcess.GetElement(elementid);
            return View("DetailsBox", new DetailsBoxViewModel((Box) element, _learningProcess, user));
        }

        public ActionResult DetailsCase(string lpid, int elementid, VKUser user)
        {
            _learningProcess = user.GetLearningProcess(lpid);
            var element = _learningProcess.GetElement(elementid);
            return View("DetailsCase", new DetailsCaseViewModel((Case) element, _learningProcess,user));
        }

        public ActionResult FillInEvaluationForm(string lpid, VKUser user)
        {
            var learningProcess = user.GetLearningProcess(lpid);
            return View("EvaluationForm",new EvaluationFormViewModel(new Evaluation(),learningProcess));
        }

        public ActionResult SaveEvaluationForm(EvaluationFormViewModel model, VKUser user)
        {
            if (ModelState.IsValid)
            {
                evaluation = new Evaluation(model,user.email);
                evaluationRepository.Add(evaluation);
                TempData["Succes"] = "Het evaluatieformulier is met succes ingediend, bedankt voor uw medewerking!";
                return RedirectToAction("DetailsLearningProcess", "LearningProcesses",
                                        new {id = model.LearningProcessCode});
            }
            return View("EvaluationForm", model);
        }
    }
}
