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
using Core.DataStructures;
using Xunit.Extensions;

namespace Tests
{
    public class MapTests
    {
        [Fact]
        public void MapCannotBeEmpty()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Map(null));
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Map(new QuadLinkedList<Parcel>(new Parcel[][] { new Parcel[] { } }))
            );
        }

        [Fact]
        public void MapWithOneParcelHasOneElement()
        {
            Map map = new Map(new QuadLinkedList<Parcel>(new Parcel[][] { new Parcel[] { Substitute.For<Parcel>() } }));
            Assert.Equal(1, map.Parcels.Count);
            Assert.NotNull(map.Parcels.First);
        }

        
    }
}
