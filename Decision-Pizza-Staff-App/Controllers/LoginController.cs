using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Decision_Pizza_Staff_App.Models;
using Decision_Pizza_Staff_App.Models.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Decision_Pizza_Staff_App.Controllers
{

    public class LoginController : Controller
    {
        private readonly IWaiterLogic login;
        private readonly IRequestShift requestShift;

        public LoginController(IWaiterLogic login, IRequestShift requestShift)
        {
            this.login = login;
            this.requestShift = requestShift;
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
        public IActionResult RejectRequestShift(WaiterManager waiterManager)
        {
            login.RejecttShift(waiterManager.TimeSlotsId);
            var ControllerDirect = RedirectToAction("Manager", "Home", waiterManager);
            return ControllerDirect;
        }

        [HttpPost]
        private IActionResult DeleteTimeSlots(WaiterManager waiterManager)
        {
            requestShift.RemoveRequests(waiterManager);
            var ControllerDirect = RedirectToAction("Manager", "Home", waiterManager);
            return ControllerDirect;
        }

        [HttpPost]
        public IActionResult ApproveRequestShift(WaiterManager waiterManager)
        {
            Console.WriteLine(waiterManager.TimeSlotsId);
            login.ApprovetShift(waiterManager.TimeSlotsId);
            var ControllerDirect = RedirectToAction("Manager", "Home", waiterManager);
            return ControllerDirect;
        }

        private IActionResult RequestShiftLogic(WaiterManager waiterManager)
        {
            var getWaiterTime = requestShift.RequestShiftSpecific(waiterManager);
            var ControllerDirect = RedirectToAction("WaitersPage", "Home", waiterManager);

            if(string.IsNullOrEmpty(waiterManager.Day) || string.IsNullOrEmpty(waiterManager.Time)){
                waiterManager.Message = "Please Select the day and time you like to request";
                return ControllerDirect;
            }

            if (getWaiterTime.Count() == 1)
            {
                waiterManager.Message = $"You alread have a Rquest for this time and Day";
                ControllerDirect = RedirectToAction("WaitersPage", "Home", waiterManager);
            }
            else {
                requestShift.InsertTimeSlots(waiterManager);
                waiterManager.Message = "Your request was recoarded";
                ControllerDirect = RedirectToAction("WaitersPage", "Home", waiterManager);
            }
            return ControllerDirect;
        }

        

        public IActionResult RedirectLoctic(string EmployId)
        {
            var results = login.GetWaiterManager(EmployId);
            var waiterManager = new WaiterManager();

            var ControllerDirect = RedirectToAction("Index", "Home");
            if (results.Count() == 0)
            {
                waiterManager.Message = "Entered employee number not found❌";
                ControllerDirect = RedirectToAction("Index", "Home", waiterManager);
            }
            else
            {
                foreach (var wm in results)
                {
                    waiterManager.EmployId = EmployId;
                    waiterManager.FullNames = wm.FullNames;
                    waiterManager.Status = wm.Status;
                    if (wm.Status == "manager")
                    {
                        ControllerDirect = RedirectToAction("Manager", "Home", waiterManager);
                    }
                    if (wm.Status == "waiter")
                    {
                        ControllerDirect = RedirectToAction("WaitersPage", "Home", waiterManager);
                    }
                }
            }
            return ControllerDirect;
        }
    }
}
