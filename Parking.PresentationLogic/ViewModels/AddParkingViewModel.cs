using Parking.Domain;
using Parking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.PresentationLogic.ViewModels
{
    public class AddParkingViewModel : BaseViewModel
    {
        private readonly IRepository<ParkingSpace> parkingRepository;
        private readonly ParkingSpace parkingSpace;
        private RelayCommand addCommand;

        public AddParkingViewModel(IRepository<ParkingSpace> parkingRepository, ParkingSpace parkingSpace)
        {
            this.parkingRepository = parkingRepository ?? throw new ArgumentNullException(nameof(parkingRepository));
            this.parkingSpace = parkingSpace;
        }

        public string Address
        {
            get => parkingSpace.Address;
            set
            {
                parkingSpace.Address = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand AddCommand => addCommand ?? (addCommand = new RelayCommand(parametr =>
        {
            parkingRepository.Add(parkingSpace);
        }));
    }
}
