using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArbetsProvGisys.Models.VM
{
    [Bind(Prefix =nameof(HomeConsultsVM.HomeConsults))]
    public class HomeConsultCreateVM
    {
        
        //[Required(ErrorMessage = "Skriv in ett giltigt förnamn! ")]
        public string Firstname { get; set; }

        //[Required(ErrorMessage = "Skriv in ett giltigt efternamn! ")]
        public string Lastname { get; set; }

        //[DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
