using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using p2g33_web.Controllers;
using p2g33_web.Models.Domain;

namespace p2g33_web.Tests.Controllers
{
    [TestClass]
    public class LearningProcessesControllerTest
    {
        private LearningProcessesController controller;
        private VKUser user;
        private Mock<IVKUserRepository> userRepository;
        private DummyContext context;

        [TestInitialize]
        public void MyTestInitialize()
        {
            context = new DummyContext();
            userRepository = new Mock<IVKUserRepository>();
            userRepository.Setup(p => p.FindAll()).Returns(context.Users);
            controller = new LearningProcessesController();
            user = context.User;

        }
        
        [TestMethod]
        public void OverviewWillShow2LearningProcesses()
        {
            ViewResult result = controller.Index(user) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(2,user.LearningProcesses.Count);
        }

        [TestMethod]
        public void DetailsWillShowLearningProcess()
        {
            ViewResult result = controller.DetailsLearningProcess("abcd2200", user) as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void DetailsWillShowOverviewOnError()
        {
            ViewResult result = controller.DetailsLearningProcess("testfoutje", user) as ViewResult;
            Assert.AreEqual("Overview",result.ViewName);
        }

    }
}
