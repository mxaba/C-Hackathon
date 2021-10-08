using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Decision_Pizza_Staff_App.Models;

namespace Decision_Pizza_Staff_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWaiterLogic login;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IWaiterLogic login)
        {
            _logger = logger;
            this.login = login;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manager(WaiterManager waiterManager)
        {
            var getWaiterTime = login.GetTimeSlots().ToList();
            var slotsAdd = new List<WaiterManager>();
            var RequestAddShift1 = new List<WaiterManager>();
            var RequestAddShift2 = new List<WaiterManager>();
            var RequestAddShift3 = new List<WaiterManager>();
            foreach (var item in getWaiterTime)
            {
                slotsAdd.Add(new WaiterManager { 
                    TimeSlotsId=item.TimeSlotsId,
                    EmployId=item.EmployId,
                    FullNames=item.FullNames,
                    Status=item.Status,
                    Time=item.Time,
                    Day=item.Day
                });

                if(item.Time == "09:00 - 12:00" && item.Status == "Approved") {
                    RequestAddShift1.Add(new WaiterManager { 
                        TimeSlotsId=item.TimeSlotsId,
                        EmployId=item.EmployId,
                        FullNames=item.FullNames,
                        Status=item.Status,
                        Time=item.Time,
                        Day=item.Day
                    });
                } if(item.Time == "12:00 - 16:00" && item.Status == "Approved") {
                    RequestAddShift2.Add(new WaiterManager { 
                        TimeSlotsId=item.TimeSlotsId,
                        EmployId=item.EmployId,
                        FullNames=item.FullNames,
                        Status=item.Status,
                        Time=item.Time,
                        Day=item.Day
                    });
                }
            }

            waiterManager.TimeslotsResults = slotsAdd;
            waiterManager.RequestAddShift1 = RequestAddShift1;
            waiterManager.RequestAddShift2 = RequestAddShift2;
            return View(waiterManager);
        }

        public IActionResult WaitersPage(WaiterManager waiterManager)
        {
            var getWaiterTime = login.GetTimeSlotsById(waiterManager).ToList();
            var slotsAdd = new List<WaiterManager>();
            foreach (var item in getWaiterTime)
            {
                slotsAdd.Add(new WaiterManager {    
                    TimeSlotsId=item.TimeSlotsId,
                    EmployId=item.EmployId,
                    FullNames=item.FullNames,
                    Status=item.Status,
                    Time=item.Time,
                    Day=item.Day
                });
            }

            waiterManager.TimeslotsResults = slotsAdd;

            return View(waiterManager);
        }

        public IActionResult TimeSlots(WaiterManager waiterManager)
        {
            return View(waiterManager);
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
