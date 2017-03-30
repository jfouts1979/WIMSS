using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WineEntryProposal.Models
{
    // ********************************************
    // *** Drop and Create the Database Only ******
    // *** If the Model Changes *******************
    // ********************************************

    public class MediaDatabaseInitializer : DropCreateDatabaseIfModelChanges<MediaContext>
    {

        // **********************************************
        // *** Seed the Database With the Data Below ****
        // **********************************************

        protected override void Seed(MediaContext context)
        {

            // *******************************************
            // *** Images To Populate Slider *************
            // *******************************************

            Gallery gallery = new Gallery
            {
               //need to add code here to populate slider...
            };


        }
        
        //*** this code is not correct ***
        //*** need to correct this code possibly to seed database with images
        //*** may not be necessary *** - should not be.
        //context.gallery.Add(gallery);
        //    context.SaveChanges();
        //    base.Seed(context);
    }

    public class MediaContext : DbContext
    {
        public DbSet<Gallery> gallery { get; set; }
    }
}