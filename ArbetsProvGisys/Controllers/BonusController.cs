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
    public class BonusController : Controller
    {
        HomeControllerReposotory reposotory;
        public BonusController(HomeControllerReposotory reposotory)
        {
            this.reposotory = reposotory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(reposotory.GetAllBonusConsults());
        }

        [HttpPost]
        public IActionResult Index(BonusCalcVM viewModel)
        {
            var model = reposotory.CalcBonus(viewModel);
            return View(model);
        }

    }
}
