using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WineEntryProposal.Models;
using WineEntryProposal.Models.ViewModels;

namespace WineEntryProposal.Controllers
{   [Authorize]
    public class WineController : Controller
    {
        // *********************************************************    
        // ********* GET: ListWine View ****************************
        // *********************************************************

        public ActionResult Index()
        {

            // *************************************************
            // *** Establish New WineContext (Plate of Data) ***
            // *** And Return the list of wine *****************
            // *************************************************

            using (var context = new WineContext())
            {
                var x = context.Wines.Include(w => w.TheVarietal).ToList();
                return View("ListWine", x);
            }

        }

        // *************************************************************
        // *************** ADD A WINE VIEW MODEL (GET) *****************
        // *************************************************************

        [HttpGet]
        public ActionResult AddWine()
        {
            // ****************************************************
            // *** Establish New Wine Add View Model For Add ******
            // *** May Also Utilize This Area of Code 4 Edit ******
            // ****************************************************

            var vm = new WineAddViewModel()
            {
                // ****************************************************
                // * Default Value Of Nullable Boolean Is Always Null *
                // * Unnecessary To Nullify But Set To Insure Value   *
                // ****************************************************

                ShowSuccessMsg = null,

                VarietalsToChooseFrom = Repository.GetAllGrapeVarietals().OrderBy(gv => gv.Name).ToList(),

                TheWine = new WineModel(),
                TheWineClass = new TTBWineClass()
            };

            //*****************************************************
            //*** Returns AddWine View (Form) For Adding A Wine ***
            //*****************************************************

            return View("AddWine", vm);
        }


        // *************************************************************
        // ***************** ADD A WINE VIEW MODEL POST ****************
        // *************************************************************

        [HttpPost]
        public ActionResult AddWine2(Models.ViewModels.WineAddViewModel wine)
        {

            // ****************************************************
            // ********* Check To Make Sure Model Is Valid ********
            // ****************************************************

            if (ModelState.IsValid)

            {

                wine.VarietalsToChooseFrom = Repository.GetAllGrapeVarietals();

                using (var context = new WineContext())
                {

                    // *************************************************
                    // * Might Be Useful To Cache For Some Time In The *   
                    // * Future To Make Sure That User Does Not Try    *
                    // * To Pass A Varietal To DB That Does Not Exist  *
                    // *************************************************
                    
                    var varietalFromDb = context.Varietals.FirstOrDefault(v => v.Id == wine.TheWine.Varietal.VarietalId)
                    ;
                    if (varietalFromDb == null)

                    {

                        throw new Exception("Received an invalid varietal name.");

                    }


                    //******************************************
                    //*** Map Field Names For The Database *****
                    //*** In New dbWine Variable ***************
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
                        TheVarietal = varietalFromDb,
                        TheWineType = wine.TheWine.WineType,
                        TheTTBWineClass = wine.TheWineClass

                    };

                    // *****************************************
                    // *** Add The New Wine To The Database ****
                    // *** And Save The Changes ****************
                    // *****************************************

                    context.Wines.Add(dbWine);
                    context.SaveChanges();
                }

                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                //      CODE NOTE USED CODE NOT USED 
                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

                var blankWine = new WineAddViewModel
                {
                    ShowSuccessMsg = true,
                    //SelectedVarietalId = null,
                    TheWine = new WineModel(),
                    VarietalsToChooseFrom = Repository.GetAllGrapeVarietals(),

                };

                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
                //      CODE NOTE USED CODE NOT USED 
                //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

                
                return RedirectToAction("Index", "Wine", wine);

            }
            
            // *************************************************
            // *** Repopulate Varietals To Choose From *********
            // *************************************************
            
            wine.VarietalsToChooseFrom = Repository.GetAllGrapeVarietals();

            //Return Some Error View - to be added...

            throw new NotImplementedException("Dealing With Errors");

        }

        // ******************************************
        // *** REMOVE A WINE VIEW MODEL (POST) ******
        // ******************************************


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            
        // ******************************************
        // ******* Establish New Data Context *******
        // ******* Wine To Delete Variable    *******
        // ******* Utilize the Include Method *******
        // ******* To Avoid LazyLoading Null  *******
        // ******* Issue That Would Cause An  *******
        // ******* Exception To Be Thrown     *******
        // ******************************************
        
        using (var WinedB = new WineContext())

            {
                Wine wineToDelete = WinedB.Wines.Include(w => w.TheVarietal).Single(w => w.Id == id);
                WinedB.Wines.Remove(wineToDelete);
                WinedB.SaveChanges();
                return RedirectToAction("Index");
            };
        }

        
        // ************************************************
        // **** Wine To Delete (Get) Method ***************
        // **** GET: /Wine/Delete/      *******************
        // ************************************************

        public ActionResult Delete(int? id)
        {
            using (var winedB = new WineContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Wine wine = winedB.Wines.Include(w => w.TheVarietal).Single(w => w.Id == id);
                if (wine == null)
                {
                    return HttpNotFound();
                }

                // ******************************************
                // *** If Wine To Delete Is Not Null, Set ***
                // *** A New WineDeleteViewModel Equal To ***
                // *** To The Wine To Delete              ***
                // ******************************************             
                
                var wineDeleteVm = new WineDeleteViewModel
                {
                    id = wine.Id,
                    Name = wine.Name,
                    Varietal = new VarietalModel
                    {
                        GrapeFam = wine.TheVarietal.grapeFam,
                        VarietalName = wine.TheVarietal.Name,
                        VarietalpictureUrl = wine.TheVarietal.pictureUrl
                    },
                    AVA = wine.AVA,
                    ABV = wine.ABV,
                    btlVol = wine.btlVol,
                    btlVolUOM = wine.btlVolUOM,
                    fluidOz = wine.fluidOz,
                    Winetype = wine.TheWineType,
                    TTBWineClass = wine.TheTTBWineClass

                };

                // ********************************************
                // *** Return the Delete Wine View with the ***
                // *** Wine To Delete View Model Variable   ***
                // ********************************************
                
                return View("DeleteWine", wineDeleteVm);
            }
        }
        
    }

}

