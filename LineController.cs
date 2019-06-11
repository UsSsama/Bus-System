using busSystem_v8.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
//using System.IdentityModel.Metadata;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace busSystem_v8.Controllers
{
    public class LineController : Controller
    {
        BusSystemDB DB = new BusSystemDB();


        /*****************************  all lines *****************************/
        [HttpGet]
        public ActionResult AllLines()
        {
            var line = DB.lines.ToList();
            
            return View(line);
        }

        /**************************    Add lines ***************************/
        // GET: Line
        [HttpGet]
        public ActionResult AddLine()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult AddLine(Line l)
        {
            if (ModelState.IsValid)
            {
                DB.lines.Add(l);
                DB.SaveChanges();
                return Json(new { result = 1});
            }
            return Json(new { result = 0 });
            /*
            if(!ModelState.IsValid)
            {
                return View("AddLine", l);
            }
            DB.lines.Add(l);
            DB.SaveChanges();

            return RedirectToAction ("AllLines");
            */
        }

        /***************************** Edit line ***************************/
        [HttpGet]
        public ActionResult EditLine(int id)
        {
            var line = DB.lines.Single(c => c.Id == id);

            return View(line);
        }

        [HttpPost]
        public ActionResult EditLine(Line l)
        {
            if (ModelState.IsValid)
            {
                var lineDB = DB.lines.Single(c => c.Id == l.Id);

                lineDB.From = l.From;
                lineDB.To = l.To;
                lineDB.NumOfBuses = l.NumOfBuses;
                lineDB.NumOfHours = l.NumOfHours;

                DB.SaveChanges();

                return Json(new { result = 1});
            }

            return Json(new { result = 0 });

            /*
            if (!ModelState.IsValid)
            {
                return View("EditLine", l);
            }
            var lineDB = DB.lines.Single(c => c.Id == l.Id);

            lineDB.From = l.From;
            lineDB.To = l.To;
            lineDB.NumOfBuses = l.NumOfBuses;
            lineDB.NumOfHours = l.NumOfHours;

            DB.SaveChanges();

            return RedirectToAction("AllLines");
            */
        }
        /********************************  show line ****************************/

        [HttpGet]
        public ActionResult showLine(int id)
        {
            var line = DB.lines.Single(c => c.Id == id);

            return View(line);
        }



        /**************************** Delete Line ***********************************/
        [HttpGet]
        public ActionResult DeleteLine(int id)
        {
            var line = DB.lines.SingleOrDefault(c => c.Id == id);
             DB.lines.Remove(line);
           // DB.Entry(line).State = EntityState.Deleted;
            DB.SaveChanges();
            return Json(new { result = 1 } ,JsonRequestBehavior.AllowGet);
           // return RedirectToAction("AllLines");
        }

    }
}