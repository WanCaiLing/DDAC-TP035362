using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DDAC.Models
{
    public class ContainerModel
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z'.\s]{1,40}$", ErrorMessage = "Information format is invalid")]
        [Display(Name = "Container Type")]
        public string ContainerName { get; set; }


        [Required]
        [RegularExpression("[0-9]{1,}", ErrorMessage = "Please key in number")]
        [Display(Name = "Bay Used")]
        public int BayUsed { get; set; }

        public int BookModelId { get; set; }
        public BookModel BookModel { get; set; }
    }
}