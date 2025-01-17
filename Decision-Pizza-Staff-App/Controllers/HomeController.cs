﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Decision_Pizza_Staff_App.Models;
using Decision_Pizza_Staff_App.Models.ModelShifts;

namespace Decision_Pizza_Staff_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWaiterLogic login;
        private readonly IManagerLogicTable managerLogicTable;

        public HomeController(IManagerLogicTable managerLogicTable, IWaiterLogic login)
        {
            this.managerLogicTable = managerLogicTable;
            this.login = login;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Manager(WaiterManager waiterManager)
        {
            managerLogicTable.ManagerLogic(waiterManager);
            return View(waiterManager);
        }

        public IActionResult WaitersPage(WaiterManager waiterManager)
        {
            var getWaiterTime = login.GetTimeSlotsById(waiterManager).ToList();
            var approvedtrScheduleShift = login.ApprovedtrScheduleShift(waiterManager).ToList();
            var slotsAdd = new List<TimeslotsResults>();
            var yourScheduledShift = new List<ScheduledShift>();
            
            foreach (var item in getWaiterTime)
            {
                slotsAdd.Add(new TimeslotsResults {    
                    TimeSlotsId=item.TimeSlotsId,
                    EmployId=item.EmployId,
                    FullNames=item.FullNames,
                    Status=item.Status,
                    Time=item.Time,
                    Day=item.Day
                });
            }

            foreach (var item in approvedtrScheduleShift)
            {
                yourScheduledShift.Add(new ScheduledShift {
                    EmployId=item.EmployId,
                    FullNames=item.FullNames,
                    Status=item.Status,
                    Time=item.Time,
                    Day=item.Day
                });
            }

            managerLogicTable.ManagerLogic(waiterManager);
            waiterManager.TimeslotsResults = slotsAdd;
            waiterManager.ScheduledShift = yourScheduledShift;

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
