using Parking.Domain.Enums;

namespace Parking.Domain.Models
{
    public class ParkingSpace : NotifyPropertyObject
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public ParkingStatus Status { get; set; }
        public int Usages { get; set; }
    }
}
