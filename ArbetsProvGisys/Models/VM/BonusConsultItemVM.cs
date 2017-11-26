using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArbetsProvGisys.Models.VM
{
    [Bind(Prefix = nameof(BonusCalcVM.ConsultList))]
    public class BonusConsultItemVM
    {
        public int Id { get; set; }
        [Range(0,8766, ErrorMessage ="Måste vara en siffra mellan 0-8766")]
        public string Firstname { get; set; }        
        public string Lastname { get; set; }     
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public double Bonus { get; set; }
        public double LoyaltyFactor { get; set; }  
    }
}
