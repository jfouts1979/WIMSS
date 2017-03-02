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
        public ActionResult Add()
        {
            var vm = new WineAddViewModel()
            {
                VarietalsToChooseFrom = Repository.GetAllGrapeVarietals(),
                TheWine = new Wine(),
                TheWineClass = new TTBWineClass()
            };

            return View("Add", vm);
        }

        [HttpPost]
        public ActionResult Add2(WineAddViewModel wine)
        {
            
            return View("Add", wine);
        }

    }
}