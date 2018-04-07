using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DDAC.Models;

namespace DDAC.ViewModel
{
    public class viewScheduleViewModel
    {

        public Schedule schedule { get; set; }

        //public Ship ship { get; set; }
        public IEnumerable<Ship> shipList { get; set; }
            
           
    }
}