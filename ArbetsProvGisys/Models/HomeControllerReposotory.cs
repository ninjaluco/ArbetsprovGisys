using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ArbetsProvGisys.Models.VM;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ArbetsProvGisys.Models
{
    public class HomeControllerReposotory : Controller
    {
        static List<HomeConsultIndexItemVM> consult = new List<HomeConsultIndexItemVM>
        {
            new HomeConsultIndexItemVM{ Id = 1, Firstname = "Bo", Lastname = "Gustavsson", Date= new DateTime(2012, 10, 12) },
            new HomeConsultIndexItemVM{ Id = 2, Firstname = "Li", Lastname = "Karlsson", Date = new DateTime(2012,1,3)},
            new HomeConsultIndexItemVM{ Id = 3, Firstname = "An", Lastname = "Reyes", Date = new DateTime(2017,11,1)}

        };

        //================Bonus Page============================================
        // Not Done!
        public BonusCalcVM GetAllBonusConsults()
        {
            return new BonusCalcVM
            {
                ConsultList = consult.Select(c => new BonusConsultItemVM
                {
                    Id = c.Id,
                    Firstname = c.Firstname,
                    Lastname = c.Lastname,
                    Date = c.Date
                }).ToArray()
            };
        }

        public BonusCalcVM CalcBonus(BonusCalcVM viewModel)
        {
            
            int totHours = 0;
            foreach (var item in viewModel.ConsultList)
            {
                totHours += item.Hours;
            }



            foreach (var item in viewModel.ConsultList)
            {
                var diff = (DateTime.Today - item.Date).TotalDays;
                //
                //if (diff == 1){ var loyaltyFactor = loyaltyFactorArr[0] }
                //else if (diff == 1.1 ){ var loyaltyFactor = loyaltyFactorArr[1] }
                //else if (diff == 1.2 ){ var loyaltyFactor = loyaltyFactorArr[2] }
                //else if (diff == 1.3){ var loyaltyFactor = loyaltyFactorArr[3] }
                //else if (diff == 1.4){ var loyaltyFactor = loyaltyFactorArr[4] }
                //else (diff >= 1.5){ var loyaltyFactor = loyaltyFactorArr[5] }

                var loyaltyFactor = 1.3; /*Math.Round(1 + 0.01*(diff / 365), 1);*/

                var bonusH = Convert.ToInt32(loyaltyFactor * item.Hours);

                item.Bonus = viewModel.NettoRes * 0.05*(bonusH / totHours);

            }

            return viewModel;
        }


        //================Consultant Page=======================================
        //Read
        public HomeConsultsVM GetAllConsults()
        {
            return new HomeConsultsVM { HomeConsultsArr = consult.ToArray() };

        }

        public HomeConsultIndexItemVM GetCunsultById(int Id)
        {
            return consult.FirstOrDefault(c => c.Id == Id);
        }

        //Delete
        public void DeleteConsult(int id)
        {

            consult.Remove(GetCunsultById(id));
        }
        //Create
        public void AddConsult(HomeConsultIndexItemVM inputConsult)
        {
            if (consult.Any())
            {
                int maxId = consult.Max(p => p.Id) + 1;
                inputConsult.Id = maxId;
            }
            else
                inputConsult.Id = 1;

            consult.Add(inputConsult);
        }
        //Update
        public void UpdateConsult(HomeConsultIndexItemVM uppdateConsult)
        {
            var consultToUpdate = GetCunsultById(uppdateConsult.Id);
            consultToUpdate.Firstname = uppdateConsult.Firstname;
            consultToUpdate.Lastname = uppdateConsult.Lastname;
            consultToUpdate.Date = uppdateConsult.Date;



        }

    }
}
