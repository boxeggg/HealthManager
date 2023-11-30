using HealthManager.Models.ViewModels;
using HealthManager.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HealthManager.Data.Entities;
using HealthManager.Repositories;

namespace MenedżerBadań.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMeasurementRepository _Mrepo;
        private readonly IDeviceRepository _Drepo;
        public HomeController(ApplicationDbContext context, ILogger<HomeController> logger, IMeasurementRepository Mrepo, IDeviceRepository Drepo)
        {
            _Mrepo = Mrepo;
            _context = context;
            _logger = logger;
            _Drepo = Drepo;
        }
         

        public IActionResult Index()
        {
            var user = _context.UserEntity.FirstOrDefault(n => n.UserName == User.Identity.Name);
            var profile = _context.ProfileEntity.FirstOrDefault(n => n.UserId == user.Id);

            return View(new HomeViewModel()
            {
                User = user,
                Profile = profile
                
            });
          
        }
        public IActionResult Bmi()
        {
            var user = _context.UserEntity.FirstOrDefault(n => n.UserName == User.Identity.Name);
            var profile = _context.ProfileEntity.FirstOrDefault(n => n.UserId == user.Id);
            _BmiViewModel vm = new _BmiViewModel() { 
                bmiResult = CalculateBmi(profile.Weight,profile.Height)
            };
            return PartialView("_Bmi", vm);
        }
        private double CalculateBmi(double weight, double height)
        {
            if (height <= 0 || weight <= 0)
            {
                return -1;
            }

            double bmi = weight / (height * height);
            return Math.Round(bmi, 2);
        }
        public IActionResult MyMeasurements()
        {
            var user = _context.UserEntity.FirstOrDefault(n => n.UserName == User.Identity.Name);
            _MyMeasurementsViewModel vm = new _MyMeasurementsViewModel()
            {
                PulseValue = _Mrepo.GetMeasurementValueByName(user.Id, BodyMeasure.Pulse),
                GlucoseValue = _Mrepo.GetMeasurementValueByName(user.Id, BodyMeasure.Glucose),
                HeightValue = _Mrepo.GetMeasurementValueByName(user.Id, BodyMeasure.Height),
                WeightValue = _Mrepo.GetMeasurementValueByName(user.Id, BodyMeasure.Weight),
                SaturationValue = _Mrepo.GetMeasurementValueByName(user.Id, BodyMeasure.Saturation)
            };
            return PartialView("_MyMeasurements",vm);
        }
        public IActionResult ConnectedDevices()
        {
            var user = _context.UserEntity.FirstOrDefault(n => n.UserName == User.Identity.Name);
            var userId = user.Id;
            _ConnectedDevicesViewModel vm = new _ConnectedDevicesViewModel() {
                Name = _Drepo.GetConnectedDeviceNames(userId)
            };


            return PartialView("_ConnectedDevices",vm);
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