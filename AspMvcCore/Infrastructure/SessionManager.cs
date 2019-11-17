using Microsoft.AspNetCore.Http;
using Models.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspMvcCore.Infrastructure
{
    public class SessionManager : ISessionManager
    {
        private ISession Session;

        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            Session = httpContextAccessor.HttpContext.Session;
        }

        public User User
        {
            get
            {
                
                return (Session.Keys.Contains(nameof(User))) ? JsonConvert.DeserializeObject<User>(Session.GetString(nameof(User))) : null;
            }

            set
            {
                Session.SetString(nameof(User), JsonConvert.SerializeObject(value));
            }
        }

        public void Abandon()
        {
            Session.Clear();
        }
    }
}
