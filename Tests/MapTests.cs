using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.IoC;
using Xunit;
using Xunit.Ioc;
using Core;

namespace Tests
{
    [RunWith(typeof(IocTestClassCommand))]
    [DependencyResolverBootstrapper(typeof(AutofacTestBootstrapper))]
    public class MapTests
    {
        private readonly IMap _map;
        
        public MapTests(IMap map)
        {
            _map = map;
        }

        [Fact]
        public void MapHasPositiveDimensions()
        {
            Assert.True(_map.Width > 0);
            Assert.True(_map.Height > 0);
        }
    }
}
