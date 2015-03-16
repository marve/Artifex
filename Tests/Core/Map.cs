using Core.DataStructures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Core
{
    public class Map : IMap
    {
        private readonly QuadLinkedList<Parcel> _parcels;

        public QuadLinkedList<Parcel> Parcels
        {
            get { return _parcels; }
        }

        // TODO: Should take a collection of Parcel. IElement should be a higher level. A map
        // contains parcels and each parcel is the same size as any other parcel. A parcel 
        // contains an element but that element may span multiple parcels. A parcel should know
        // what it's neighboring parcels (north, south, east, west) are.
        public Map(QuadLinkedList<Parcel> parcels)
        {
            if (parcels == null || parcels.Count <= 0)
            {
                throw new ArgumentOutOfRangeException("Must have at least one parcel in a map.");
            }
            _parcels = parcels;
        }
    }
}
