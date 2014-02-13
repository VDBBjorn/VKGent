using Mvc.Mailer;
using p2g33_web.Models.ViewModels;

namespace p2g33_web.Mailer
{
    public class UserMailer: MailerBase, IUserMailer
    {
        public UserMailer()
		{
			MasterName="_Layout";
		}

        public virtual MvcMailMessage RequestTraining(TrainingViewModel model)
        {
            ViewBag.Model = model;
            return Populate(mailModel =>
            {
                mailModel.Subject = "Aanvraag vorming";
                mailModel.ViewName = "RequestTraining";
                mailModel.To.Add("p2g332013@outlook.com");
            });
        }

    }
}