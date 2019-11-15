using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ToolBox.Patterns.Locator
{
    public abstract class LocatorBase
    {
        protected IServiceProvider Container { get; private set; }

        public LocatorBase()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            Configure(serviceCollection);
            Container = serviceCollection.BuildServiceProvider();
        }

        internal abstract void Configure(IServiceCollection serviceCollection);
    }
}
