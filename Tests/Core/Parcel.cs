using Core.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Parcel : QuadLinkedList<Parcel>.QuadLinkedListElement
    {
        public Parcel(
            Parcel north = null,
            Parcel east = null,
            Parcel south = null,
            Parcel west = null) : base(north, east, south, west)
        {

        }
    }
}
