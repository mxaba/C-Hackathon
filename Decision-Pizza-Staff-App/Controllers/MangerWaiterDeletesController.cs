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

    public class MangerWaiterDeletesController : Controller
    {
        private readonly IRequestShift requestShift;

        public MangerWaiterDeletesController(IRequestShift requestShift)
        {
            this.requestShift = requestShift;
        }

        

        [HttpPost]
        public IActionResult DeleteTimeSlots(WaiterManager waiterManager)
        {
            requestShift.RemoveRequests(waiterManager);
            var ControllerDirect = RedirectToAction("Manager", "Home", waiterManager);
            return ControllerDirect;
        }

        [HttpPost]
        public IActionResult RemovePending(WaiterManager waiterManager)
        {
            requestShift.RemovePendingRequest(waiterManager);
            var ControllerDirect = RedirectToAction("WaitersPage", "Home", waiterManager);
            return ControllerDirect;
        }
    }
}
