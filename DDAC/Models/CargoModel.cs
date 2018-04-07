using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDAC.Models
{
    public class Ship
    {
        public int Id { get; set; } 

        [Display(Name= "Ship Name")]
        [Required]
        [StringLength(20, ErrorMessage = "Cannot exceed 20 characters")]
        public string ShipName { get; set; }
        // public DateTime DepartureDateTime { get; set; }
        //public DateTime ArrivalDateTime { get; set; }


        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Information format is invalid")]
        [Display(Name = "Ship Destination")]
        [Required]
        public string ShipDestination { get; set; }


        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Information format is invalid")]
        [Display (Name="Ship Starting Point")]
        [Required]
        public string ShipStartingPoint { get; set; }

        [Display (Name="Cargo Size")]
        [Range(10, 1000)]
        [Required]
        public int CargoSize { get; set; }

        [Required]
        [Display(Name = "Remaining Cargo Size")]
        public int RemainingCargoSize { get; set; }

    }

    public class Schedule

    {
        public int Id { get; set; }

        
        [Required]
        [Display(Name="Ship Departure Date")]
        public DateTime ShipDepartureDate { get; set; }

        [Required]
        [Display(Name="Ship Arrival Date")]
        public DateTime ShipArrivalDate { get; set; }

        [Required]
        [Display(Name="Origin")]
        public string OriginalPlace { get; set; }

        [Required]
        [Display(Name="Destination")]
        public string DestinationPlace { get; set; }

        [Required]
        public int ShipId { get; set; }

        public Ship ShipData { get; set; }

       


    }
}