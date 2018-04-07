using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DDAC.Models;

namespace DDAC.Controllers
{
    public class ShipController : Controller
    {
        private ApplicationDbContext _context;

        public ShipController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Ship
        public ActionResult Index()
        {
            var ship = _context.Ship.ToList();

            return View(ship);
        }

        public ActionResult addShip()
        {

            return View();

        }

        [HttpPost]
        public ActionResult createShip(Ship ship)
        {
            if (!ModelState.IsValid)
            {
                return View("addShip");
            }

            ship.RemainingCargoSize = ship.CargoSize;

            _context.Ship.Add(ship);
            _context.SaveChanges();



            return RedirectToAction("Index", "Ship");

        }

       
    }
}