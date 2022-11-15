using Parking.Domain;
using Parking.Domain.Comparers;
using Parking.Domain.Enums;
using Parking.Domain.Extensions;
using Parking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking.PresentationLogic.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private readonly IRepository<ParkingSpace> parkingRepository;
        private readonly INavigationService navigationService;
        private readonly ParkingSpacesComparer parkingSpacesComparer;
        private RelayCommand changeStatusCommand;
        private RelayCommand editCommand;
        private RelayCommand deleteCommand;
        private RelayCommand createCommand;

        public MainWindowViewModel(IRepository<ParkingSpace> parkingRepository, INavigationService navigationService, ParkingSpacesComparer parkingSpacesComparer)
        {
            this.parkingRepository = parkingRepository ?? throw new ArgumentNullException(nameof(parkingRepository));
            this.navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            this.parkingSpacesComparer = parkingSpacesComparer ?? throw new ArgumentNullException(nameof(parkingSpacesComparer));
            List<ParkingSpace> parkingSpaces = parkingRepository.GetAll().ToList();
            parkingSpaces.Sort(this.parkingSpacesComparer);
            Parkings = new ObservableCollection<ParkingSpace>(parkingSpaces);
        }

        public ObservableCollection<ParkingSpace> Parkings { get; set; }

        public RelayCommand ChangeStatusCommand => changeStatusCommand ?? (changeStatusCommand = new RelayCommand(parametr =>
        {
            if (parametr is ParkingSpace parkingSpace)
            {
                parkingSpace.Status = parkingSpace.Status
                                      == ParkingStatus.Enabled ? ParkingStatus.Disabled : ParkingStatus.Enabled;
                parkingRepository.Update(parkingSpace);
                Parkings.Update(parkingSpace);
            }
        }));

        public RelayCommand EditCommand => editCommand ?? (editCommand = new RelayCommand(parametr =>
        {
            if (parametr is ParkingSpace parkingSpace)
            {
                navigationService.ShowWindow<EditParkingViewModel>(parkingSpace);
                parkingRepository.Update(parkingSpace);
                Parkings.Update(parkingSpace);
            }
        }));

        public RelayCommand DeleteCommand => deleteCommand ?? (deleteCommand = new RelayCommand(parametr =>
        {
            if (parametr is ParkingSpace parkingSpace)
            {
                parkingRepository.Delete(parkingSpace.Id);
                Parkings.Remove(parkingSpace);
            }
        }));

        public RelayCommand CreateCommand => createCommand ?? (createCommand = new RelayCommand(parametr =>
        {
            ParkingSpace parkingSpace = new ParkingSpace();
            navigationService.ShowWindow<AddParkingViewModel>(parkingSpace);
            if (parkingSpace.Id != 0)
                Parkings.Add(parkingSpace);
        }));
    }
}
