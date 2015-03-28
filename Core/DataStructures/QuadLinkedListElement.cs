using Functional.Option;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataStructures
{
    public class QuadLinkedListElement<T> : IQuadLinkedListElement<T>
    {
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
            QuadLinkedListElement<T> west)
        {
            Contract.Requires(value != null);
            _value = value;
            West = west;
        }
    }
}
