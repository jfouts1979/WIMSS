using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WineEntryProposal.Controllers
{
    public class VendorsController : Controller
    {
        // GET: Vendor
        public ActionResult Index()
        {
            return View();
        }
    }
}