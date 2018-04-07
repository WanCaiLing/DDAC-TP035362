using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using DDAC.Models;
using DDAC.ViewModel;
using Microsoft.Ajax.Utilities;

namespace DDAC.Controllers
{
    public class ScheduleController : Controller
    {
        private ApplicationDbContext _context;

        public ScheduleController()
        {

            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {

            _context.Dispose();

        }
        // GET: Schedule
        public ActionResult Index()
        {
            var schedule = _context.Schedule.ToList();

            return View(schedule);
        }

        public ActionResult addSchedule()
        {
            viewScheduleViewModel vsvm = new viewScheduleViewModel
            {
                shipList = _context.Ship.DistinctBy(s => s.ShipStartingPoint).ToList()
            };

            return View(vsvm);
        }

        public ActionResult createSchedule(Schedule schedule)
        {
            
            if (schedule.Id == 0)
            {
                
                _context.Schedule.Add(schedule);

            }
            else
            {

                var ScheduleInDb = _context.Schedule.Single(c => c.Id == schedule.Id);

                ScheduleInDb.DestinationPlace = schedule.DestinationPlace;
                ScheduleInDb.OriginalPlace = schedule.OriginalPlace;
                ScheduleInDb.ShipDepartureDate = schedule.ShipDepartureDate;
                ScheduleInDb.ShipArrivalDate = schedule.ShipArrivalDate;
                


            }


            _context.SaveChanges();


            return RedirectToAction("Index", "Schedule");
            

        }


        public ActionResult Destination(string starting)
        {
            var destination = _context.Ship.Where(s => s.ShipStartingPoint == starting).ToList().DistinctBy(s => s.ShipDestination);

            return Json(destination, JsonRequestBehavior.AllowGet);
        }

        public ActionResult specifyShip(string start, string destination)
        {
            var chooseShip = _context.Ship.Where(s => s.ShipStartingPoint == start && s.ShipDestination == destination).ToList();

            return Json(chooseShip, JsonRequestBehavior.AllowGet);

        }

        public ActionResult editSchedule(int id)
        {
            var schedule = _context.Schedule.SingleOrDefault(c => c.Id == id);

            if (schedule == null)
            {

                return HttpNotFound();

            }

            var viewModel = new viewScheduleViewModel
            {
                schedule = schedule,

                shipList = _context.Ship.ToList()


            };

            return View(viewModel);

        }

       

     










    }
}