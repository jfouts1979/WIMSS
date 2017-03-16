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
                VarietalsToChooseFrom = Repository.GetAllGrapeVarietals().OrderBy(gv => gv.Name).ToList(),

               // VarietalsToChooseFrom = Repository.GetAllGrapeVarietals().OrderBy(gv => gv.Name).ToList()
               // VarietalsToChooseFrom = Repository.GetAllGrapeVarietals().ToList().OrderBy(gv => gv.Name),
                TheWine = new Wine(),
                //TheWineClass = new TTBWineClass()
            };

            return View("AddWine", vm);
        }

        // ****************************************************************
        // ************      ADD A WINE VIEW MODEL POST *******************
        // ****************************************************************

        [HttpPost]
        public ActionResult AddWine2(WineAddViewModel wine)
        {

            //Added this line in to fix problem with System.Core.Dll error /null
            //Problem was that information was not bound to the form.  Shouldn't
            //I have to do this for all of the other form controls?
            //No -they are contained in TheWine.  So why do I need to send 

            // Provides Varietal Information in TheVarietal Variable.

            wine.TheWine.TheVarietal = Repository.GetAllGrapeVarietals().FirstOrDefault(gv => gv.Id == int.Parse(wine.SelectedVarietalId));

            // Provides the list of VarietalsToChooseFrom to post to server.

            wine.VarietalsToChooseFrom = Repository.GetAllGrapeVarietals();

            //*****************************************
            //*** Establish Database Wines Table*******
            //*****************************************

            using (var context = new WineContext())
            {
                context.Wines.Add(wine.TheWine);
                context.SaveChanges();

            }

            //*****************************************
            //*****************************************


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