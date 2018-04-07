using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;


namespace DDAC.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Information format is invalid")]
        [Display(Name = "Customer Name")]
        public string customerName { get; set; }

       
        [Required]
        [RegularExpression("[0-9]{1,}", ErrorMessage = "Please key in number")]
        [Display(Name="IC Number")]
        [MinLength(10, ErrorMessage = "Invalid IC Number")]
        public string icNum { get; set; }

        [Required]
        [RegularExpression("[0-9]{1,}", ErrorMessage = "Invalid Contact Number")]
        [MinLength(10, ErrorMessage = "Invalid Contact Number")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(11, ErrorMessage = "Invalid Contact Number")]
        [Display(Name = "Contact Number")]
        public string contactNum { get; set; }

        [Required]
        [Display(Name="Email")]
        [EmailAddress]
        public string customerEmail { get; set; }

        public string agentName { get; set; }




    }
}