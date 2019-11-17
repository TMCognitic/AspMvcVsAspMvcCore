using AspMvcCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMvcCore.Controllers
{
    [IsLoggedAction]
    public class ControllerBase : Controller
    {
        protected internal ISessionManager SessionManager { get; private set; }

        public ControllerBase(ISessionManager sessionManager)
        {
            SessionManager = sessionManager;            
        }
    }
}
