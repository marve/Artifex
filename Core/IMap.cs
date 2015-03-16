using Core.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public interface IMap
    {
        QuadLinkedList<Parcel> Parcels { get; }
    }
}
