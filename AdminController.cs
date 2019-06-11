using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using busSystem_v8.Models;
using System.Data.Entity;
using busSystem_v8.Controllers;
namespace busSystem_v8.Controllers
{
    public class AdminController : Controller
    {
        User info;
        BusSystemDB db = new BusSystemDB();
        // GET: Admin
        public ActionResult Index()
        {
            //var info = Session["userData"] as User;
            //if (info == null || info.user_types_id == 2)
            //{
            //    return RedirectToAction("page_error_404");
            //}
            //else
            //{
                return View();
            //}
        }
       
        /********** pages *********/
        public ActionResult page_error_404()
        {
            return View();
        }
    }
}