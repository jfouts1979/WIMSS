﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WineEntryProposal.Models;
using WineEntryProposal.Models.ViewModels;

namespace WineEntryProposal.Controllers
{
    public class WineController : Controller
    {
        // GET: Wine

        public ActionResult Index()
        {

            // Return the list of wine

            using (var context = new WineContext())
            {
                var x = context.Wines.Include(w => w.TheVarietal).ToList();
                return View("ListWine", x);
            }

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

            //******************************************
            //*** Returns the form for adding a wine ***
            //******************************************

            return View("AddWine", vm);
        }


        // *************************************************************
        // ************      ADD A WINE VIEW MODEL POST ****************
        // *************************************************************

        [HttpPost]
        public ActionResult AddWine2(Models.ViewModels.WineAddViewModel wine)
        {

            if (ModelState.IsValid)

            {

                // Provides Varietal Information in TheVarietal Variable.

                // This might be something to cache for some time in the future to make sure that user does not try to send a varietal that is not
                // in the database to the app.


                // Provides the list of VarietalsToChooseFrom to post to server.

                wine.VarietalsToChooseFrom = Repository.GetAllGrapeVarietals();

                //*****************************************
                //*** Establish Database Wines Table*******
                //*****************************************

                using (var context = new WineContext())
                {

                    var varietalFromDb = context.Varietals.FirstOrDefault(v => v.Id == wine.TheWine.Varietal.VarietalId)
                    ;
                    if (varietalFromDb == null)

                    {

                        throw new Exception("Received an invalid varietal name.");

                    }


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


                        TheVarietal = varietalFromDb,

                        // Could not make WineType nullable in WineModel...
                        // TheWineType means like Table or Dessert...

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
                    ///SelectedVarietalId = null,
                    TheWine = new WineModel(),
                    VarietalsToChooseFrom = Repository.GetAllGrapeVarietals(),

                };



                return RedirectToAction("Index", "Wine", wine);

                //put this in the view somewhere but where?
                //< p > @ViewBag.result < p />
            }
            wine.VarietalsToChooseFrom = Repository.GetAllGrapeVarietals();

            //Return Some Error View - to be added...

            throw new NotImplementedException("Dealing With Errors");

        }


        // My first attempt....updated 3/23/2017 after several attempts.

        // ******************************************
        // ***** REMOVE A WINE VIEW MODEL POST *******
        // ******************************************


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed (int id) 
        {                                              
            using (var WinedB = new WineContext())
            
            {
                Wine wineToDelete = WinedB.Wines.Find(id);
                WinedB.Wines.Remove(wineToDelete);
                WinedB.SaveChanges();
                return RedirectToAction("Index");               
            };
        }

        // GET: /Wine/Delete/
        public ActionResult Delete(int? id)
        {
            using (var winedB = new WineContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Wine wine = winedB.Wines.Find(id);
                if (wine == null)
                {
                    return HttpNotFound();
                }
                return View("DeleteWine");
            }
        }


    }

  
        //    // *************************************************************
        //    // ******      REMOVE A WINE VIEW MODEL POST *******************
        //    // *************************************************************

        //    //    [HttpPost, ActionName("Delete")]
        //    //    [ValidateAntiForgeryToken]

        //    //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    //    {
        //    //        var student = await _context.Wines
        //    //            .AsNoTracking()
        //    //            .SingleOrDefaultAsync(m => m.ID == id);
        //    //        if (student == null)
        //    //        {
        //    //            return RedirectToAction("Index");
        //    //        }

        //    //        try
        //    //        {
        //    //            context.Wines.Remove(Wine);
        //    //            await context.SaveChangesAsync();
        //    //            return RedirectToAction("Index");
        //    //        }
        //    //        catch (DbUpdateException /* ex */)
        //    //        {
        //    //            //Log the error (uncomment ex variable name and write a log.)
        //    //            return RedirectToAction("Delete", new { id = id, saveChangesError = true });
        //    //        }
        //    //    }

        //    //    public interface IActionResult
        //    //    {
        //    //    }
        //    //}

    }

