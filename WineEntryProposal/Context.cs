using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WineEntryProposal.Models;
using System.Data.Entity.Validation;

namespace WineEntryProposal
{
    //public class Context : DbContext
    //{
    //    public Context()
    //    {
    //        Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());

    //    }
    //}


    public class WineContext : DbContext
    {


        public WineContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<WineContext>());

        }
        public DbSet<Wine> Wines { get; set; }
        public DbSet<GrapeVarietal> Varietals { get; set; }
        //public DbSet<TTBWineClass> TTBWineClasses { get; set; }

     
       
    }

   


}