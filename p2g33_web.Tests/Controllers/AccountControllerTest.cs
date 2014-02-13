using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using p2g33_web.Controllers;
using p2g33_web.Models;
using p2g33_web.Models.DAL;
using p2g33_web.Models.Domain;

namespace p2g33_web.Tests.Controllers
{
    [TestClass]
    public class AccountControllerTest
    {
        private AccountController controller;
        private Mock<IVKUserRepository> _userRepository;
        private DummyContext _context;
        
        [TestInitialize]
        public void MyTestInitialize()
        {
            _context = new DummyContext();
            _userRepository = new Mock<IVKUserRepository>();
            _userRepository.Setup(p => p.FindAll()).Returns(_context.Users);
            controller = new AccountController();
        }

        [TestMethod]
        public void TestMethod1()
        {
            VKUser user = new VKUser();
            user.email = "kenneth";
            user.password = "pas";

            LoginModel loginModel = new LoginModel();
            loginModel.UserName = user.email;
            loginModel.Password = user.password;


            var result = controller.Login(loginModel, "%2fLearningProcesses%2fOverview") as ViewResult;


            if (result != null)
                Assert.AreEqual("Index",result.ViewName);

            //Assert.That(result.ViewName, Is.EqualTo("Index"));
            //Assert.False(controller.ModelState.IsValid);
            //Assert.That(controller.ModelState[""],
            //            Is.EqualTo("The user name or password provided is incorrect."));
        }
    }
}
