using Parking.Domain;
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
        private RelayCommand changeStatusCommand;
        private RelayCommand editCommand;

        public MainWindowViewModel(IRepository<ParkingSpace> parkingRepository, INavigationService navigationService)
        {
            this.parkingRepository = parkingRepository ?? throw new ArgumentNullException(nameof(parkingRepository));
            this.navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            Parkings = new ObservableCollection<ParkingSpace>(parkingRepository.GetAll());
        }

        public ObservableCollection<ParkingSpace> Parkings { get; set; }

        public RelayCommand ChangeStatusCommand => changeStatusCommand ?? (changeStatusCommand = new RelayCommand(parametr =>
        {

     
        }));

        public RelayCommand EditCommand => editCommand ?? (editCommand = new RelayCommand(parametr =>
        {


        }));
    }
}
