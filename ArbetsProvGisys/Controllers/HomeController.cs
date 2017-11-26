using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ArbetsProvGisys.Models.VM;
using ArbetsProvGisys.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArbetsProvGisys.Controllers
{
    public class HomeController : Controller
    {

        HomeControllerReposotory reposotory;
        public HomeController(HomeControllerReposotory reposotory)
        {
            this.reposotory = reposotory;
        }
        
       
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BonusCalc()
        {
            
            return View();
        }
        
        [HttpGet]
        public IActionResult Consults()
        {
            var model = reposotory.GetAllConsults();
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            reposotory.DeleteConsult(id);
            return RedirectToAction(nameof(Consults));
        }

        [HttpPost]
        public IActionResult Update(HomeConsultIndexItemVM consult)
        {
            reposotory.UpdateConsult(consult);
            return RedirectToAction(nameof(Consults));
        }

        [HttpPost]
        public IActionResult Create(HomeConsultIndexItemVM inputConsult)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            reposotory.AddConsult(inputConsult);
            return RedirectToAction(nameof(Consults));
        }


    }
}
