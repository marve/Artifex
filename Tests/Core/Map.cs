using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Core
{
    public class Map : IMap
    {
        private const int WIDTH = 100;
        private const int HEIGHT = 100;

        private readonly List<IElement> _elements;
        private readonly ReadOnlyCollection<IElement> _elementsReadOnly;

        public int Width
        {
            get { return WIDTH; }
        }

        public int Height
        {
            get { return HEIGHT; }
        }

        public IReadOnlyList<IElement> Elements
        {
            get { return _elementsReadOnly; }
        }

        public Map()
        {
            _elements = new List<IElement>();
            _elementsReadOnly = _elements.AsReadOnly();
        }

        public void Add(IElement element)
        {
            _elements.Add(element);
        }

        public void Remove(IElement element)
        {
            _elements.Remove(element);
        }
    }
}
