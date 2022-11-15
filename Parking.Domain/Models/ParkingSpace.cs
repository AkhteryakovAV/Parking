using Parking.Domain.Enums;
using System;

namespace Parking.Domain.Models
{
    public class ParkingSpace : NotifyPropertyObject, IEquatable<ParkingSpace>
    {
        private string address;
        private ParkingStatus status;
        private int usages;

        public int Id { get; set; }
        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged();
            }
        }
        public ParkingStatus Status
        {
            get => status;
            set
            {
                OnParkingStatusChanged(value);
            }
        }
        public int Usages
        {
            get => usages;
            set
            {
                usages = value;
                OnPropertyChanged();
            }
        }

        public bool Equals(ParkingSpace other)
        {
            return Id == other.Id && Address == other.Address;
        }
        public override string ToString()
        {
            return Address;
        }
        private void OnParkingStatusChanged(ParkingStatus changedStatus)
        {
            if (status != changedStatus)
            {
                status = changedStatus;
                OnPropertyChanged(nameof(Status));
                if (status == ParkingStatus.Disabled)
                    Usages++;
            }

        }
    }
}
