using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WineEntryProposal.Controllers;
using WineEntryProposal.Models;
using WineEntryProposal.Views.Wine;

namespace WineEntryProposal.Views
{
    //***********************************************
    //*** Repository ***
    //***********************************************

    public static class Repository
    {

        public static List<GrapeVarietal> GetAllGrapeVarietals()
        {

            using (var context = new WineContext())
            {
                return context.Varietals.ToList();
            }
        }

        //public static List<TTBActiveWinePermit> GetAllPermits()
        //{
            
            //using (var context = new WineContext())
            //{
            //    //var list = context.wineriesByPermitByState.ToList();
            //    var list2 = new List<TTBActiveWinePermit>();
            //    foreach (var permit in context.TTBActiveWinePermits)
            //    {
            //        list2.Add(permit);
            //    }
            //    return list2;
               
            //}
            //var list = TTBWinePermitsController.


        //}

    }
}