using Parking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.PresentationLogic.ViewModels
{
    public class EditParkingViewModel : BaseViewModel
    {
        private readonly ParkingSpace parkingSpace;

        public EditParkingViewModel(ParkingSpace parkingSpace)
        {
            this.parkingSpace = parkingSpace ?? throw new ArgumentNullException(nameof(parkingSpace));
        }

        public int ParkingId => parkingSpace.Id;
        public string Address
        {
            get => parkingSpace.Address;
            set 
            {
                parkingSpace.Address = value;
                OnPropertyChanged();
            }
        }

    }
}
