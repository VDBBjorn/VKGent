using System;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Security;
using p2g33_web.Models;
using p2g33_web.Models.DAL;
using p2g33_web.Models.Domain;

namespace p2g33_web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        //
        // GET: /Account/Login

        private IVKUserRepository userRepository;
        private VKUser user;

        public AccountController(IVKUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        
        public AccountController()
        {
            userRepository = new VKUserRepository(new P2G33Context());
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                user = userRepository.FindBy(model);
                if (user!=null)
                {
                    if (model.RememberMe)
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                        HttpContext.User = new GenericPrincipal(new GenericIdentity(model.UserName),
                                                                new string[] {"gebruiker"});
                    }
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    TempData["Succes"] = "U bent succesvol ingelogd!";
                    return RedirectToAction("Index", "LearningProcesses");
                }
            }
            ModelState.AddModelError("", "Verkeerde inloggegevens.");
            return View(model);            
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            TempData["Info"] = "U bent succesvol uitgelogd!";
            return RedirectToAction("Index", "Home");
        }
    }
}
