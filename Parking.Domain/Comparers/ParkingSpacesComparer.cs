using Parking.Domain.Models;
using System.Collections.Generic;

namespace Parking.Domain.Comparers
{
    public class ParkingSpacesComparer : IComparer<ParkingSpace>
    {
        public int Compare(ParkingSpace x, ParkingSpace y)
        {
            return x.Address.CompareTo(y.Address);
        }
    }
}
