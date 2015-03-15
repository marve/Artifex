using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public interface IMap
    {
        int Width { get; }

        int Height { get; }

        void Add(IElement element);

        void Remove(IElement element);

        IReadOnlyList<IElement> Elements { get; }
    }
}
