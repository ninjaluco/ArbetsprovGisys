using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArbetsProvGisys.Models.VM
{
    public class BonusCalcVM
    {
        public int NettoRes { get; set; }
        public BonusConsultItemVM[] ConsultList { get; set; }
    }
}
