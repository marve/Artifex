using Functional.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataStructures
{
    public interface IQuadLinkedListElement<T>
    {
        T Value { get; }
        Option<IQuadLinkedListElement<T>> North { get; }
        Option<IQuadLinkedListElement<T>> East { get; }
        Option<IQuadLinkedListElement<T>> South { get; }
        Option<IQuadLinkedListElement<T>> West { get; }
    }
}
