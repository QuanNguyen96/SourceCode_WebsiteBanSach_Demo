using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication4.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult GioiThieu()
        {
            return View();
        }
        public ActionResult LienHe()
        {
            return View();
        }
        public ActionResult HuongDan()
        {
            return View();
        }
    }
}