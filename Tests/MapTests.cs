using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.IoC;
using Xunit;
using Xunit.Ioc;
using Core;
using NSubstitute;

namespace Tests
{
    [RunWith(typeof(IocTestClassCommand))]
    [DependencyResolverBootstrapper(typeof(AutofacTestBootstrapper))]
    public class MapTests
    {
        private readonly Map _map;
        
        public MapTests(Map map)
        {
            _map = map;
        }

        [Fact]
        public void MapHasPositiveDimensions()
        {
            Assert.True(_map.Width > 0);
            Assert.True(_map.Height > 0);
        }

        [Fact]
        public void MapCanHostElement()
        {
            IElement element = Substitute.For<IElement>();
            _map.Add(element);
            Assert.Equal(1, _map.Elements.Count);
        }

        [Fact]
        public void MapCanRemoveElement()
        {
            IElement element = Substitute.For<IElement>();
            _map.Add(element);
            _map.Remove(element);
            Assert.Equal(0, _map.Elements.Count);
        }
    }
}
