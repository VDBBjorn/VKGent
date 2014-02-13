using p2g33_web.Models;
using p2g33_web.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace p2g33_web.Infrastructure
{
    public class VKUserModelBinder: IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext.HttpContext.User.Identity.IsAuthenticated)
            {
                IVKUserRepository repository = (IVKUserRepository)DependencyResolver.Current.GetService(typeof(IVKUserRepository));
                return repository.FindBy(controllerContext.HttpContext.User.Identity.Name);
            }
            return null;
        }

    }
}