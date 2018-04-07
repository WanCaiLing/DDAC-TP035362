using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDAC.Models;

namespace DDAC.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Customer
        public ActionResult Index()
        {
            var customer = _context.Customer.ToList();
            return View(customer);
        }

        [HttpGet]
        public ActionResult RegisterCustomer()
        {

            return View();

        }

        [HttpPost]
        public ActionResult RegisterCustomer(CustomerModel cm)
        {
            if (ModelState.IsValid)
            {
                cm.agentName = User.Identity.Name;
                _context.Customer.Add(cm);
                _context.SaveChanges();

                ViewBag.Message = "Customer has been registered successful";
                ViewBag.Success = true;

                return RedirectToAction("Index", "Customer");
            }
            else
            {
                ViewBag.Message = "Registered Failed";
                ViewBag.Success = false;

                return View();

            }

        }
    }
}