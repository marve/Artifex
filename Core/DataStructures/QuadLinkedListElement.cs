using System.Diagnostics.Contracts;

namespace Core.DataStructures
{
    public class QuadLinkedListElement<T> : IQuadLinkedListElement<T>
    {
        private readonly T _value;

        public T Value
        {
            get { return _value; }
        }
        public IQuadLinkedListElement<T> North { get; set; }
        public IQuadLinkedListElement<T> East { get; set; }
        public IQuadLinkedListElement<T> South { get; set; }
        public IQuadLinkedListElement<T> West { get; set; }

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
