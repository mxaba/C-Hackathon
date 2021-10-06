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
        private readonly ILogin login;

        public LoginController(ILogin login)
        {
            this.login = login;
        }

        // GET: /<controller>/
        [HttpPost]
        public IActionResult Login(string EmployId)
        {
            var results = login.GetWaiterManager(EmployId);
            var ControllerDirect = RedirectToAction("Index", "Home");
            if (results.Count() == 0)
            {
                TempData["error"] = "I don't have an employee number";
                ControllerDirect = RedirectToAction("Index", "Home");
            } else
            {
                foreach(var wm in results)
                {
                    if(wm.Status == "manager")
                    {
                        TempData["manager"] = EmployId;
                        ControllerDirect = RedirectToAction("Manager", "Home");
                    }
                    if (wm.Status == "waiter")
                    {
                        ControllerDirect = RedirectToAction("WaitersPage", "Home", new WaiterManager(){
                            EmployId = EmployId,
                            FullNames = wm.FullNames,
                            Status = wm.Status,
                            Message = $"Welcome {wm.FullNames}"
                        });
                    }
                }
            }
            return ControllerDirect;
        }
    }
}
