using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DDAC.Models;

namespace DDAC.ViewModel
{
    public class BookingViewModel
    {
        public Schedule Schedule { get; set; }
        public BookModel BookModel { get; set; }
        public List<CustomerModel> CustomerModels { get; set; }
        public CustomerModel CustomerModel { get; set; }
        public ContainerModel ContainerModel { get; set; }
    }
}