using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p2g33_web.Models.Domain;

namespace p2g33_web.Tests.Controllers
{
    class DummyContext
    {
        private IList<VKUser> users;

        public DummyContext()
        {
            users = new List<VKUser>();
            for (var i = 0; i < 20; i++)
            {
                users.Add(new VKUser { email = "user" + i + "@student.hogent.be", password = "password" + i, LearningProcesses = { new LearningProcess { learningProcessCode = "abcd2200", title = "abcd2200" } } });
            }
        }

        public IQueryable<VKUser> Users
        {
            get { return users.AsQueryable(); }
        }

        public VKUser User
        {
            get { return new VKUser {email = "teststudent@student.hogent.be", password = "password", LearningProcesses = { new LearningProcess {learningProcessCode = "abcd2200", title="dit is een titel"},
                                                                                                     new LearningProcess{learningProcessCode = "abcd2215",title="dit is een andere titel"}}}; }
        }
    }
}