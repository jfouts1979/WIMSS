using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WineEntryProposal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Customers()
        {
            return View("Construction");
        }

        public ActionResult About()
        {
            ViewBag.Message = "A Solution For Ever Changing Needs In the Industries Administered By Local, State, and Federal ATC, ABC, Liquor Control Boards, and the Federal Tax and Trade Bureau (TTB). .";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}