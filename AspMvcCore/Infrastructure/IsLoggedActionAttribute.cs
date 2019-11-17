using AspMvcCore.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMvcCore.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class, Inherited=true)]
    public class IsLoggedActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ControllerBase controller = (ControllerBase)context.Controller;
            controller.ViewBag.IsLogged = !(controller.SessionManager.User is null);
        }
    }
}
