using Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspMvc.Infrastructrure
{
    public static class SessionManager
    {
        public static User User
        {
            get { return (User)HttpContext.Current.Session[nameof(User)]; }
            set { HttpContext.Current.Session[nameof(User)] = value; }
        }

        public static void Abandon()
        {
            HttpContext.Current.Session.Abandon();
        }
    }
}