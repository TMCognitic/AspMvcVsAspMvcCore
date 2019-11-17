using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Models.Data;
using Models.Services;
using Repositories;
using ToolBox.Connections.Database;
using ToolBox.Patterns.Locator;

namespace AspMvc.Models.Locator
{
    public class ServicesLocator : LocatorBase
    {
        private static ServicesLocator _instance;

        public static ServicesLocator Instance
        {
            get
            {
                return _instance ??= new ServicesLocator();
            }
        }

        protected override void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IConnection, Connection>(factory => new Connection(SqlClientFactory.Instance, ConfigurationManager.ConnectionStrings["DemoDatabase"].ConnectionString))
                .AddSingleton<IAuthRepository<User>, AuthService>()
                .AddSingleton<IContactRepository<Contact>, ContactService>();
        }

        public IAuthRepository<User> AuthService
        {
            get { return (IAuthRepository<User>)Container.GetService(typeof(IAuthRepository<User>)); }
        }

        public IContactRepository<Contact> ContactService
        {
            get { return (IContactRepository<Contact>)Container.GetService(typeof(IContactRepository<Contact>)); }
        }
    }
}
