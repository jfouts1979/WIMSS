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

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                     .SelectMany(x => x.ValidationErrors)
                     .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
    }
}
    