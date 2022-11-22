using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Parking.Domain;
using Parking.Domain.Models;
using Parking.Website.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Parking.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<ParkingSpace> _parkingRepository;

        public HomeController(ILogger<HomeController> logger, IRepository<ParkingSpace> parkingRepository)
        {
            _logger = logger;
            _parkingRepository = parkingRepository ?? throw new ArgumentNullException(nameof(parkingRepository));
        }

        public async Task<IActionResult> Index()
        {
            return View(
                await Task.Run(() => _parkingRepository.GetAll()));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
