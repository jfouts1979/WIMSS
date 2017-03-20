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

    public class MyDatabaseInitializer : DropCreateDatabaseIfModelChanges<WineContext> {

        protected override void Seed(WineContext context)
        {
            var list = new List<GrapeVarietal>() {
            new GrapeVarietal() { Id = 1, Name = "Vidal Blanc" },
                new GrapeVarietal() { Id = 2, Name = "Concord", pictureUrl= "http://res.cloudinary.com/dqhopogso/image/upload/v1489462544/ConcordGrapes2.png" },
                new GrapeVarietal() { Id = 3, Name = "Pinot Noir" },
                new GrapeVarietal() { Id = 4, Name = "Pinot Grigio" },
                new GrapeVarietal() { Id = 5, Name = "Niagara" },
                new GrapeVarietal() { Id = 6, Name = "Catawba" },
                new GrapeVarietal() { Id = 7, Name = "Steuben" },
                new GrapeVarietal() { Id = 8, Name = "Chambourcin" },
                new GrapeVarietal() { Id = 9, Name = "Vignoles" },
                new GrapeVarietal() { Id = 10, Name = "Merlot" },
                new GrapeVarietal() { Id = 11, Name = "Cabernet Sauvignon" },
                new GrapeVarietal() { Id = 12, Name = "Sauvignon Blanc" },
                new GrapeVarietal() { Id = 13, Name = "Jupiter" },
                new GrapeVarietal() { Id = 14, Name = "Vanessa" },
                new GrapeVarietal() { Id = 15, Name = "Canidice" },
                new GrapeVarietal() { Id = 16, Name = "Norton" },
                new GrapeVarietal() { Id = 17, Name = "Malbec" },
                new GrapeVarietal() { Id = 18, Name = "Chambourcin" },
                new GrapeVarietal() { Id = 19, Name = "Chardonel" },
                new GrapeVarietal() { Id = 20, Name = "Chardonnay" },
                new GrapeVarietal() { Id = 21, Name = "Traminette", pictureUrl="http://res.cloudinary.com/dqhopogso/image/upload/v1489462782/Traminette.jpg" },
                new GrapeVarietal() { Id = 22, Name = "Seyval Blanc" },
                new GrapeVarietal() { Id = 23, Name = "Gewürztraminer" },
                new GrapeVarietal() { Id = 24, Name = "Marechal Foch" }
                };

            context.Varietals.AddRange(list);
            context.SaveChanges();
            base.Seed(context);
        }

    }

    public class WineContext : DbContext
    {


        public WineContext() :base("WineDb")
        {
            Database.SetInitializer(new MyDatabaseInitializer());

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
    