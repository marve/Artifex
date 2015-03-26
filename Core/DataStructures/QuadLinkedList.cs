using Functional.Option;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataStructures
{
    public class QuadLinkedList<T>
    {
        private readonly Option<IQuadLinkedListElement<T>> _first;
        private readonly int _count;

        /// <summary>
        /// The north-west most element.
        /// </summary>
        public Option<IQuadLinkedListElement<T>> First
        {
            get { return _first; }
        }

        public int Count
        {
            get { return _count; }
        }

        public QuadLinkedList(params T[][] rows)
        {
            Contract.Requires(rows != null);
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

        private Option<IQuadLinkedListElement<T>> BuildRows(T[][] rows)
        {
            Option<IQuadLinkedListElement<T>> first = new Option<IQuadLinkedListElement<T>>();
            QuadLinkedListElement<T>[] previousRow = null;
            foreach (T[] row in rows)
            {
                previousRow = BuildRow(previousRow, row);
                first.Match(None: () => first = previousRow.First());
            }
            return first;
        }

        private QuadLinkedListElement<T>[] BuildRow(QuadLinkedListElement<T>[] rowAbove, T[] row)
        {
            QuadLinkedListElement<T>[] currentRow = new QuadLinkedListElement<T>[row.Length];
            QuadLinkedListElement<T> previous = null;
            // row should never be null, but above might.
            for (int i = 0; i < row.Length; i++)
            {
                QuadLinkedListElement<T> west = previous;
                QuadLinkedListElement<T> current = new QuadLinkedListElement<T>(row[i], west: west);
                if (rowAbove != null)
                {
                    current.North = rowAbove[i];
                    rowAbove[i].South = current;
                }
                if (previous != null)
                {
                    previous.East = current;
                }
                previous = current;
                currentRow[i] = current;
            }
            return currentRow;
        }
    }
}
