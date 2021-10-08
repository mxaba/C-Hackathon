using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Decision_Pizza_Staff_App.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Decision_Pizza_Staff_App.Controllers
{

    public class LoginController : Controller
    {
        private readonly IWaiterLogic login;

        public LoginController(IWaiterLogic login)
        {
            this.login = login;
        }

        // GET: /<controller>/
        [HttpPost]
        public IActionResult Login(string EmployId)
        {
            return RedirectLoctic(EmployId);
        }

        [HttpPost]
        public IActionResult RequestShift(WaiterManager waiterManager)
        {
            return RequestShiftLogic(waiterManager);
        }

        [HttpPost]
        public IActionResult RejectRequestShift(int? EmployId)
        {
            return View();
        }

        // [HttpPost]
        public IActionResult ApproveRequestShift(int id, WaiterManager waiterManager)
        {
            Console.WriteLine(waiterManager.FullNames);
            Console.WriteLine(id);
            login.ApproveRequestShift(id);
            var ControllerDirect = RedirectToAction("Manager", "Home",
                        new WaiterManager()
                        {
                            FullNames = waiterManager.FullNames,
                        });
            return ControllerDirect;
        }

        private IActionResult RequestShiftLogic(WaiterManager waiterManager)
        {
            var getWaiterTime = login.GetTimeSlotsById(waiterManager);
            Console.WriteLine(getWaiterTime.Count());
            var ControllerDirect = RedirectToAction("WaitersPage", "Home");

            if (getWaiterTime.Count() == 0)
            {
                login.InsertTimeSlots(waiterManager);
                ControllerDirect = RedirectToAction("WaitersPage", "Home",
                        new WaiterManager()
                        {
                            EmployId = waiterManager.EmployId,
                            FullNames = waiterManager.FullNames,
                            Status = waiterManager.Status,
                            Message = $"Your request was recoarded"
                        });
            }
            else
            {
                foreach (var item in getWaiterTime)
                {
                    if (item.Day == waiterManager.Day && item.Time == waiterManager.Time)
                    {
                        ControllerDirect = RedirectToAction("WaitersPage", "Home",
                        new WaiterManager()
                        {
                            EmployId = item.EmployId,
                            FullNames = item.FullNames,
                            Status = item.Status,
                            Message = $"Your request for this {item.Day} @ {item.Time} the status is {item.Status}",
                        });
                    }
                    else
                    {
                        login.InsertTimeSlots(waiterManager);
                        ControllerDirect = RedirectToAction("WaitersPage", "Home",
                                new WaiterManager()
                                {
                                    EmployId = item.EmployId,
                                    FullNames = item.FullNames,
                                    Status = item.Status,
                                    Message = $"Your request was recoarded",
                                });
                    }
                }
            }
            return ControllerDirect;
        }

        public IActionResult RedirectLoctic(string EmployId)
        {
            // var getWaiterTime = login.GetTimeSlots(new WaiterManager(){EmployId = EmployId}).ToList();
            var results = login.GetWaiterManager(EmployId);

            var ControllerDirect = RedirectToAction("Index", "Home");
            if (results.Count() == 0)
            {
                new WaiterManager(){Message = "I don't have an employee number"};
                ControllerDirect = RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var wm in results)
                {
                    if (wm.Status == "manager")
                    {
                        // foreach (var item in collection)
                        // {
                            
                        // }
                        TempData["manager"] = EmployId;
                        ControllerDirect = RedirectToAction("Manager", "Home",new WaiterManager()
                        {
                            EmployId = EmployId,
                            FullNames = wm.FullNames,
                            Status = wm.Status
                        });
                    }
                    if (wm.Status == "waiter")
                    {

                        ControllerDirect = RedirectToAction("WaitersPage", "Home", new WaiterManager()
                        {
                            EmployId = EmployId,
                            FullNames = wm.FullNames,
                            Status = wm.Status,
                            Message = ""
                        });
                    }
                }
            }
            return ControllerDirect;
        }
    }
}
