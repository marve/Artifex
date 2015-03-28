using System;

namespace Core.DataStructures
{
    public interface IQuadLinkedListElement<T>
    {
        T Value { get; }
        IQuadLinkedListElement<T> North { get; }
        IQuadLinkedListElement<T> East { get; }
        IQuadLinkedListElement<T> South { get; }
        IQuadLinkedListElement<T> West { get; }
    }
}
