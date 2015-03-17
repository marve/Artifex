using Functional.Option;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataStructures
{
    public class QuadLinkedListElement<T> : IQuadLinkedListElement<T>, IEquatable<QuadLinkedListElement<T>>
    {
        private readonly Guid _id = Guid.NewGuid();
        private readonly T _value;

        public T Value
        {
            get { return _value; }
        }
        public Option<IQuadLinkedListElement<T>> North { get; set; }
        public Option<IQuadLinkedListElement<T>> East { get; set; }
        public Option<IQuadLinkedListElement<T>> South { get; set; }
        public Option<IQuadLinkedListElement<T>> West { get; set; }

        public QuadLinkedListElement(
            T value,
            QuadLinkedListElement<T> north = null,
            QuadLinkedListElement<T> east = null,
            QuadLinkedListElement<T> south = null,
            QuadLinkedListElement<T> west = null)
        {
            Contract.Requires(value != null);
            _value = value;
            North = north;
            East = east;
            South = south;
            West = west;
        }

        public bool Equals(QuadLinkedListElement<T> other)
        {
            if (other == null)
            {
                return false;
            }
            return other._id.Equals(_id);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as QuadLinkedListElement<T>);
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }
    }
}
