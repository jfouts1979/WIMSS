using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
        
        // Return the list of wine

            return View();
        }

        // *************************************************************
        // **************   ADD A WINE VIEW MODEL GET *****************
        // *************************************************************

        [HttpGet]
        public ActionResult AddWine()
        {
            var vm = new WineAddViewModel()
            {
                // Default value of nullable boolean is always null
                // so un-necessary to nullify it but want to make it null
                // so I understand completely.

                ShowSuccessMsg = null,

                VarietalsToChooseFrom = Repository.GetAllGrapeVarietals().OrderBy(gv => gv.Name).ToList(),

               // VarietalsToChooseFrom = Repository.GetAllGrapeVarietals().OrderBy(gv => gv.Name).ToList()
               // VarietalsToChooseFrom = Repository.GetAllGrapeVarietals().ToList().OrderBy(gv => gv.Name),
                TheWine = new WineModel(),
                //TheWineClass = new TTBWineClass()
            };

            return View("AddWine", vm);
        }

        // *************************************************************
        // ************      ADD A WINE VIEW MODEL POST ****************
        // *************************************************************

        [HttpPost]
        public ActionResult AddWine2(WineAddViewModel wine)
        {



                if (ModelState.IsValid)

                {

                // Provides Varietal Information in TheVarietal Variable.

                // This might be something to cache for some time in the future to make sure that user does not try to send a varietal that is not
                // in the database to the app.
                
                var varietal = Repository.GetAllGrapeVarietals().FirstOrDefault(gv => gv.Id == wine.SelectedVarietalId);

                if (varietal == null) 
                
                {

                    throw new Exception("Received an invalid varietal name.");

                }

                    // Provides the list of VarietalsToChooseFrom to post to server.

                    wine.VarietalsToChooseFrom = Repository.GetAllGrapeVarietals();

                    //*****************************************
                    //*** Establish Database Wines Table*******
                    //*****************************************

                    using (var context = new WineContext())
                    {

                    //******************************************
                    //*** map field names for the database *****
                    //******************************************

                    var dbWine = new Wine

                    {
                        ABV = wine.TheWine.ABV,
                        AVA = wine.TheWine.AVA,
                        btlVol = wine.TheWine.btlVol,
                        btlVolUOM = wine.TheWine.btlVolUOM,
                        fluidOz = wine.TheWine.fluidOz,
                        Id = wine.TheWine.Id,
                        Name = wine.TheWine.Name,
                        
                        //  These lines need to be set up as tables in the database context...  
                        //  And then populated with information...

                        // TheTTBWineClass = wine.TheWine.TTBWineClass,
                        // TheVarietal = wine.TheWine.TheVarietal,

                         // Could not make WineType nullable in WineModel...
                         TheWineType = wine.TheWine.WineType

                    };
                        context.Wines.Add(dbWine);
                        context.SaveChanges();
                    }

                //*****************************************
                //*****************************************

                var blankWine = new WineAddViewModel
                {
                    ShowSuccessMsg = true,
                    SelectedVarietalId = null,
                    TheWine = new WineModel(),
                    VarietalsToChooseFrom = Repository.GetAllGrapeVarietals(),
                    
                };

                           

                return View("AddWine", blankWine);

                    //put this in the view somewhere but where?
                    //< p > @ViewBag.result < p />
                }
            wine.VarietalsToChooseFrom = Repository.GetAllGrapeVarietals();
            return View("AddWine", wine);
                
            }
             
                       
         }

              // ******************************************
              // ***** REMOVE A WINE VIEW MODEL GET *******
              // ******************************************

        //[HttpGet]
        //public ActionResult RemoveWine()
        //{
        //    var vm = new WineRemoveViewModel()
        //    {
        //        VarietalsToChooseFrom = Repository.GetAllGrapeVarietals(),
        //        TheWine = new Wine(),
        //        TheWineClass = new TTBWineClass()
        //    };

        //    return View("RemoveWine", vm);
        //}

        // *************************************************************
        // ******      REMOVE A WINE VIEW MODEL POST *******************
        // *************************************************************
 
        //[HttpPost]
        //public ActionResult RemoveWine2(WineRemoveViewModel wine)
        //{
        //    return View("RemoveWine", wine);
        //}
        
    }
