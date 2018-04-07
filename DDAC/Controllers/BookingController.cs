using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDAC.Models;
using DDAC.ViewModel;

namespace DDAC.Controllers
{
    public class BookingController : Controller
    {
        private ApplicationDbContext _context;

        public BookingController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Booking
        public ActionResult Index()
        {
            var show = _context.Schedule.Include(s => s.ShipData).ToList();
            return View(show);
        }

        public ActionResult ViewBooking()
        {
            var viewbooking = _context.ContainerModels.Include(v => v.BookModel.customer).Include(v => v.BookModel).Include(v => v.BookModel.schedule).Include(v => v.BookModel.schedule.ShipData).ToList();

            return View(viewbooking);
        }


        public ActionResult MakeBooking(int id)
        {


            var selected = _context.Schedule.Include(s => s.ShipData).SingleOrDefault(s => s.Id == id);
            var customer = _context.Customer.Where(c => c.agentName == User.Identity.Name).ToList();

            var book = new BookingViewModel
            {
                Schedule = selected,
                CustomerModels = customer
            };

            

            return View(book);
        }

        public ActionResult Book(BookingViewModel bvm)
        {

            BookingViewModel booking = new BookingViewModel
            {
                Schedule = _context.Schedule.Include(s => s.ShipData).SingleOrDefault(s => s.Id == bvm.Schedule.Id),
                CustomerModels = _context.Customer.Where(c => c.agentName == User.Identity.Name).ToList()
            };

            if (!ModelState.IsValid) //check whether is the form filled in completely.
            {
                ViewBag.Success = "fail";
                ViewBag.Message = "Fail to book";
                return View("MakeBooking", booking);
            }
            

            if (bvm.ContainerModel.BayUsed > bvm.Schedule.ShipData.RemainingCargoSize) //check whether agent input baynumber got exceed the original bay number or not
            {
                ViewBag.Success = "fail";
                ViewBag.Message = "Number of Ship Bay is insufficient";
                return View("MakeBooking", booking);
            }

            var ship = _context.Ship.SingleOrDefault(s => s.Id == bvm.Schedule.ShipId); // retrieve the remaining bay from DB based on the shipID
            ship.RemainingCargoSize = bvm.Schedule.ShipData.RemainingCargoSize - bvm.ContainerModel.BayUsed; // update the remaining bay number by deducting the bay used by agent
            _context.SaveChanges(); // save the updated changes

            //---------------------------------1st part store the booking into booking table 1st.
            var book = new BookModel
            {
                customerID = bvm.BookModel.customerID,
                scheduleId = bvm.Schedule.Id,
                bayVolume = bvm.ContainerModel.BayUsed
            };

            _context.BookModels.Add(book);
            _context.SaveChanges();
            var test = _context.BookModels.ToList().LastOrDefault();

            //--------------------------------- 2nd part retrieve the latest booking id and store into the container table
            var container = new ContainerModel
            {
                ContainerName = bvm.ContainerModel.ContainerName,
                BayUsed = bvm.ContainerModel.BayUsed,
                BookModelId = test.Id
            };
            _context.ContainerModels.Add(container);
            _context.SaveChanges();

            
            ViewBag.Success = "success";
            ViewBag.Message = "Success to book";
                


            return View("MakeBooking", booking);
        }


    }
}
