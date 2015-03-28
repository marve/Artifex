using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Xunit.Extensions;
using Core.DataStructures;
using Functional.Option;
using Xunit;

namespace Tests.DataStructures
{
    public class QuadLinkedListTests
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(10, 10)]
        [InlineData(100, 100)]
        [InlineData(3, 7)]
        [InlineData(4, 8)]
        [InlineData(9, 9)]
        [InlineData(7, 7)]
        [InlineData(75, 105)]
        public void QuadLinkedListCanTraverseWestEastNorthSouthWithoutHittingSameReferenceTwice(int rows, int columns)
        {
            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();
            QuadLinkedList<Phony> list = new QuadLinkedList<Phony>(GenerateElements(rows, columns));
            stopwatch.Stop();
            IList<Phony> elements = Traverse(list.First).ToList();
            Assert.Equal(rows * columns, elements.Count);
            foreach (Phony element in elements)
            {
                Assert.Equal(1, elements.Where(p => ReferenceEquals(p, element)).Count());
            }
        }

        private List<Phony> Traverse(Option<IQuadLinkedListElement<Phony>> element)
        {
            List<Phony> values = new List<Phony>();
            element.Match(Some: value =>
            {
                values.Add(value.Value);
                if (!value.North.HasValue)
                {
                    values.AddRange(Traverse(value.East));
                }
                values.AddRange(Traverse(value.South));
            });
            return values;
        }

        private Phony[][] GenerateElements(int rows, int columns)
        {
            return Enumerable.Range(0, rows).Select(rowIndex =>
            {
                return Enumerable.Range(0, columns).Select(columnIndex =>
                {
                    return new Phony();
                }).ToArray();
            }).ToArray();
        }

        private class Phony
        {

        }
    }
}
