using Autofac;
using Core.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Ioc;
using Xunit.Ioc.Autofac;

namespace Tests.IoC
{
    public class AutofacTestBootstrapper : IDependencyResolverBootstrapper
    {
        public static readonly IContainer Container;
        public static readonly IDependencyResolver DependencyResolver;

        static AutofacTestBootstrapper()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<AutofacModule>();
            containerBuilder.RegisterModule(new TestsModule(typeof(AutofacTestBootstrapper).Assembly));
            Container = containerBuilder.Build();
            DependencyResolver = new AutofacDependencyResolver(Container);
        }

        public IDependencyResolver GetResolver()
        {
            return DependencyResolver;
        }
    }
}
