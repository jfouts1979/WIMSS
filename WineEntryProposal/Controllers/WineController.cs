using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineEntryProposal.Models;

namespace WineEntryProposal.Controllers
{
    public class WineController : Controller
    {
        // GET: Wine
        public ActionResult Index()
        {
        // return the list of wine
            return View();
        }

        [HttpGet]
        public ActionResult AddWine()
        {
            var vm = new WineAddViewModel()
            {
                VarietalsToChooseFrom = Repository.GetAllGrapeVarietals(),
                TheWine = new Wine(),
                TheWineClass = new TTBWineClass()
            };

            return View("AddWine", vm);
        }

        [HttpPost]
        public ActionResult AddWine2(WineAddViewModel wine)
        {
            
            return View("AddWine", wine);
        }

    }
}