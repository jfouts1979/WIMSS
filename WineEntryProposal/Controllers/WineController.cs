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

        // ****************************************************************
        // ************      ADD A WINE VIEW MODEL GET ********************
        // ****************************************************************

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

        // ****************************************************************
        // ************      ADD A WINE VIEW MODEL POST *******************
        // ****************************************************************

        [HttpPost]
        public ActionResult AddWine2(WineAddViewModel wine)
        {
            return View("AddWine", wine);
        }

        // ****************************************************************
        // *********      REMOVE A WINE VIEW MODEL GET ********************
        // ****************************************************************

        [HttpGet]
        public ActionResult RemoveWine()
        {
            var vm = new WineRemoveViewModel()
            {
                VarietalsToChooseFrom = Repository.GetAllGrapeVarietals(),
                TheWine = new Wine(),
                TheWineClass = new TTBWineClass()
            };

            return View("RemoveWine", vm);
        }

        // ****************************************************************
        // *********      REMOVE A WINE VIEW MODEL POST *******************
        // ****************************************************************
 
        [HttpPost]
        public ActionResult RemoveWine2(WineRemoveViewModel wine)
        {
            return View("RemoveWine", wine);
        }
        
    }
}