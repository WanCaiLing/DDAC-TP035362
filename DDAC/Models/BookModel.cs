using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDAC.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required]
        public int bayVolume { get; set; }

        public CustomerModel customer { get; set; }

        [Required]
        public int customerID { get; set; }

        public int scheduleId { get; set; }
        public Schedule schedule { get; set; }

    }
}