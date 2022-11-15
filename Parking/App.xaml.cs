using Parking.Domain;
using Parking.Domain.Comparers;
using Parking.Domain.Models;
using Parking.InMemoryDataAccess;
using Parking.PresentationLogic;
using Parking.PresentationLogic.ViewModels;
using Parking.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Parking
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application, INavigationService
    {
        private readonly IRepository<ParkingSpace> parkingRepository;

        private readonly MainContext context;
        private readonly INavigationService navigationService;

        public App()
        {
            context = new MainContext();
            parkingRepository = new InMemoryRepository<ParkingSpace>(context);
            navigationService = this;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ShowWindow<MainWindowViewModel>();
        }

        public void ShowWindow<TViewModel>(object parametr = null) where TViewModel : BaseViewModel
        {
            Window window = CreateWindow(typeof(TViewModel), parametr);
            _ = (window?.ShowDialog());
        }

        private Window CreateWindow(Type viewModelType, object parametr)
        {
            if (viewModelType == typeof(MainWindowViewModel))
            {
                return new MainWindow(new MainWindowViewModel(parkingRepository, navigationService, new ParkingSpacesComparer()));
            }
            else if (viewModelType == typeof(EditParkingViewModel) 
                && parametr is ParkingSpace parkingSpace)
            {
                return new EditParkingView(new EditParkingViewModel(parkingSpace));
            }
            else if(viewModelType == typeof(AddParkingViewModel) && parametr is ParkingSpace addedParkingSpace)
            {
                return new AddParkingView(new AddParkingViewModel(parkingRepository, addedParkingSpace));
            }

            return null;
        }
    }
}
