using Assignment4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment4.Controllers
{
    public class SaleController : Controller
    {
        Assignment4Entities db;
        // GET: Sale
        public ActionResult Index()
        {
            
            db = new Assignment4Entities();

            var obj = (from s in db.saleinfoes
                       select new salesinfo
                       {
                           _name = s.name,
                           _contact_no = s.contact_no,
                           _contact_email = s.contact_email,
                           _address = s.address,
                           _city = s.city,
                           _car_make = s.car_make,
                           _car_model = s.car_model,
                           _car_year = s.car_year
                       }).ToList<salesinfo>();

            db.Dispose();
            return View(obj);
        }

        public ActionResult AddInfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddInfo(salesinfo obj)
        {
            saleinfo oSel = new saleinfo()
            {
                name = obj._name,
                address = obj._address,
                city = obj._city,
                contact_email = obj._contact_email,
                contact_no = obj._contact_no,
                car_make = obj._car_make,
                car_model = obj._car_model,
                car_year = obj._car_year
            };

            db = new Assignment4Entities();
            db.saleinfoes.Add(oSel);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}