using System;
using System.Web.Mvc;
using Recaptcha.Web;
using Recaptcha.Web.Mvc;
using p2g33_web.Mailer;
using p2g33_web.Models.DAL;
using p2g33_web.Models.Domain;
using p2g33_web.Models.ViewModels;

namespace p2g33_web.Controllers
{
    public class HomeController : Controller
    {
        private IUserMailer _userMailer = new UserMailer();
        public IUserMailer UserMailer
        {
            get { return _userMailer; }
            set { _userMailer = value; }
        }

        private IVKUserRepository userRepository;

        public HomeController(IVKUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ActionResult Index()
        {
            return View("Home");
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Training()
        {
            return View(new TrainingViewModel());
        }

        public ActionResult IntroductionPackage()
        {
            return View(new IntroductionViewModel());
        }

        [HttpPost]
        public ActionResult RequestTraining(TrainingViewModel model)
        {
            RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();
            if (String.IsNullOrEmpty(recaptchaHelper.Response))
            {
	            ModelState.AddModelError("", "Gelieve de captcha in te vullen");
                    return View("Training",model);
            }
            RecaptchaVerificationResult recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();
            if (recaptchaResult != RecaptchaVerificationResult.Success)
            {	
	            ModelState.AddModelError("", "Verkeerde captcha");
            }
            if (ModelState.IsValid)
            {
                UserMailer.RequestTraining(model).Send();
                TempData["Succes"] = "Aanvraagformulier met succes verzonden!";
                return RedirectToAction("Training");
            }
            return View("Training", model);
        }

        [HttpPost]
        public ActionResult RequestIntroductionPackage(IntroductionViewModel model)
        {
            RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();
            if (String.IsNullOrEmpty(recaptchaHelper.Response))
            {
	            ModelState.AddModelError("", "Gelieve de captcha in te vullen");
                    return View("IntroductionPackage",model);
            }
            RecaptchaVerificationResult recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();
            if (recaptchaResult != RecaptchaVerificationResult.Success)
            {	
	            ModelState.AddModelError("", "Verkeerde captcha");
            }
            if (ModelState.IsValid)
            {
                userRepository.CreateTrialUser(model);
                TempData["Succes"] = "Uw account werd gecreëerd, u ontvangt weldra uw inloggegevens";
                return View("Home");
            }
            return View("IntroductionPackage", model);
        }
        }


    }

