using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataStructures
{
    public class QuadLinkedList<T>
    {
        private readonly QuadLinkedListElement _first;
        private readonly int _count;

        /// <summary>
        /// The north-west most element.
        /// </summary>
        public QuadLinkedListElement First
        {
            get { return _first; }
        }

        public int Count
        {
            get { return _count; }
        }

        public QuadLinkedList(params T[][] rows)
        {
            if (rows == null || !rows.Any())
            {
                throw new ArgumentNullException("Must have rows!");
            }
            IList<int> distinctCounts = rows.Select(p => p.Length).Distinct().ToList();
            if (distinctCounts.Count() != 1)
            {
                throw new ArgumentOutOfRangeException("All rows must have the same number of elements.");
            }
            if (distinctCounts.First() == 0)
            {
                throw new ArgumentOutOfRangeException("Must have at least one item.");
            }
            _first = BuildRows(rows);
            _count = rows.Length * rows[0].Length;
        }

        private QuadLinkedListElement BuildRows(T[][] rows)
        {
            QuadLinkedListElement first = null;
            QuadLinkedListElement[] previousRow = null;
            foreach (T[] row in rows)
            {
                previousRow = BuildRow(previousRow, row);
                if (first == null)
                {
                    first = previousRow.First();
                }
            }
            return first;
        }

        private QuadLinkedListElement[] BuildRow(QuadLinkedListElement[] rowAbove, T[] row)
        {
            QuadLinkedListElement[] currentRow = new QuadLinkedListElement[row.Length];
            QuadLinkedListElement previous = null;
            // row should never be null, but above might.
            for (int i = 0; i < row.Length; i++)
            {
                QuadLinkedListElement north = null;
                if (rowAbove != null)
                {
                    north = rowAbove[i];
                }
                QuadLinkedListElement west = previous;
                QuadLinkedListElement current = new QuadLinkedListElement(row[i], north: north, west: west);
                if (previous != null)
                {
                    previous.East = current;
                }
                previous = current;
                currentRow[i] = current;
            }
            return currentRow;
        }

        //public QuadLinkedListElement NorthMost(QuadLinkedListElement current)
        //{
        //    return Traverse(current, p => p.North);
        //}

        //public QuadLinkedListElement WestMost(QuadLinkedListElement current)
        //{
        //    return Traverse(current, p => p.West);
        //}

        //private QuadLinkedListElement Traverse(
        //    QuadLinkedListElement current, 
        //    Func<QuadLinkedListElement, QuadLinkedListElement> heading)
        //{
        //    QuadLinkedListElement next = heading(current);
        //    if (next == null)
        //    {
        //        return current;
        //    }
        //    return Traverse(next, heading);
        //}

        //public int CountHopsToSouthMost(QuadLinkedListElement current)
        //{
        //    return CountHops(current, p => p.South);
        //}

        //public int CountHopsToEastMost(QuadLinkedListElement current)
        //{
        //    return CountHops(current, p => p.East);
        //}

        //private int CountHops(
        //    QuadLinkedListElement current,
        //    Func<QuadLinkedListElement, QuadLinkedListElement> heading)
        //{
        //    QuadLinkedListElement next = heading(current);
        //    if (next == null)
        //    {
        //        return 0;
        //    }
        //    return CountHops(next, heading) + 1;
        //}

        public class QuadLinkedListElement : IEquatable<QuadLinkedListElement>
        {
            private readonly Guid _id = Guid.NewGuid();
            private readonly T _value;

            public T Value
            {
                get { return _value; }
            }
            public QuadLinkedListElement North { get; internal set; }
            public QuadLinkedListElement East { get; internal set; }
            public QuadLinkedListElement South { get; internal set; }
            public QuadLinkedListElement West { get; internal set; }

            public QuadLinkedListElement(
                T value,
                QuadLinkedListElement north = null,
                QuadLinkedListElement east = null,
                QuadLinkedListElement south = null,
                QuadLinkedListElement west = null)
            {
                _value = value;
                North = north;
                East = east;
                South = south;
                West = west;
            }

            private void Test()
            {

            }

            public bool Equals(QuadLinkedListElement other)
            {
                if (other == null)
                {
                    return false;
                }
                return other._id.Equals(_id);
            }

            public override bool Equals(object obj)
            {
                return Equals(obj as QuadLinkedListElement);
            }

            public override int GetHashCode()
            {
                return _id.GetHashCode();
            }
        }
    }
}
