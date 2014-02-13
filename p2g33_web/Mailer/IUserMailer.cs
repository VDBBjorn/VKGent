using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mvc.Mailer;
using p2g33_web.Models.ViewModels;

namespace p2g33_web.Mailer
{
    public interface IUserMailer
    {
        MvcMailMessage RequestTraining(TrainingViewModel model);
    }
}
