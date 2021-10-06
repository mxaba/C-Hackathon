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
                        TempData["error"] = "Hey i am a mananger";
                        ControllerDirect = RedirectToAction("Manager", "Home");
                    }
                    if (wm.Status == "waiter")
                    {
                        TempData["error"] = "Hey i am a Waiter";

                    }
                }
            }

            Console.WriteLine(EmployId);

            Console.WriteLine(results.Count());
            return ControllerDirect;
        }
    }
}
