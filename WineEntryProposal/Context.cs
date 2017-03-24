using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using WineEntryProposal.Models;
using System.Data.Entity.Validation;

namespace WineEntryProposal
{
    // ********************************************
    // *** Drop and Create the Database Only ******
    // *** If the Model Changes *******************
    // ********************************************

    public class MyDatabaseInitializer : DropCreateDatabaseIfModelChanges<WineContext>
    {

        // **********************************************
        // *** Seed the Database With the Data Below ****
        // **********************************************
    
        protected override void Seed(WineContext context)
        {
            
            // *******************************************
            // *** List of Grape Varietals Eventually ****
            // *** To Be Pulled from 27 e-CFR Ch. 1   ****
            // *** Subchapter A Part 4 Subchapter J   ****
            // *** 4.91 **********************************
            // *** Most Likely Using A Streamreader ******
            // *******************************************
            
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

            // ***************************************************
            // *** Establish Listing Of Non Grape Fruit Sources **
            // *** Including Average Brix Levels - Brix Is A *****
            // *** Measure of Sugar Solids.  Numbers Below From  *
            // *** Cornell University                          ***
            // ***************************************************

            var fruitlist = new List<NGFruitSourceType>()
        {
           new NGFruitSourceType() { Id=20, Name="Apple", Brix=13.3 },
           new NGFruitSourceType() { Id=21, Name="Apricot", Brix = 14.3 },
           new NGFruitSourceType() { Id=22, Name="Bilberry", Brix = 13.4 },
           new NGFruitSourceType() { Id=23, Name="Whortleberry", Brix = 13.4 },
           new NGFruitSourceType() { Id=24, Name="Vaccinium", Brix = 13.4 },
           new NGFruitSourceType() { Id=25, Name="Myrtillium", Brix = 13.4 },
           new NGFruitSourceType() { Id=26, Name="Black Currant", Brix = 15.0 },
           new NGFruitSourceType() { Id=27, Name="Blackberry", Brix = 10.0 },
           new NGFruitSourceType() { Id=28, Name="Black Raspberry", Brix = 11.1 },
           new NGFruitSourceType() { Id=29, Name="Blueberry", Brix = 14.1 },
           new NGFruitSourceType() { Id=30, Name="Boysenberry", Brix = 10.0 },
           new NGFruitSourceType() { Id=31, Name="Carob", Brix = 40.0 },
           new NGFruitSourceType() { Id=32, Name="Cherry", Brix = 14.3 },
           new NGFruitSourceType() { Id=33, Name="Crabapple", Brix = 15.4 },
           new NGFruitSourceType() { Id=34, Name="Cranberry", Brix = 10.5 },
           new NGFruitSourceType() { Id=35, Name="Date", Brix = 18.5 },
           new NGFruitSourceType() { Id=36, Name="Dewberry", Brix = 10.0 },
           new NGFruitSourceType() { Id=37, Name="Elderberry", Brix = 11.0 },
           new NGFruitSourceType() { Id=38, Name="Fig", Brix = 18.2 },
           new NGFruitSourceType() { Id=39, Name="Grape (Vitis Vinifera)", Brix = 21.5 },
           new NGFruitSourceType() { Id=40, Name="Grape (Slipskin Varieties)", Brix = 16.0 },
           new NGFruitSourceType() { Id=41, Name="Grapefruit", Brix = 10.2 },
           new NGFruitSourceType() { Id=42, Name="Guava", Brix = 7.7 },
           new NGFruitSourceType() { Id=43, Name="Lemon", Brix = 8.9 },
           new NGFruitSourceType() { Id=44, Name="Lime", Brix = 10.0 },
           new NGFruitSourceType() { Id=45, Name="Loganberry", Brix = 10.5 },
           new NGFruitSourceType() { Id=46, Name="Mango", Brix = 17.0 },
           new NGFruitSourceType() { Id=47, Name="Naranjilla", Brix = 10.5 },
           new NGFruitSourceType() { Id=48, Name="Orange", Brix = 11.8 },
           new NGFruitSourceType() { Id=49, Name="Papaya", Brix = 10.2 },
           new NGFruitSourceType() { Id=50, Name="Passion Fruit", Brix = 15.3 },
           new NGFruitSourceType() { Id=51, Name="Peach", Brix = 11.8 },
           new NGFruitSourceType() { Id=52, Name="Pear", Brix = 15.4 },
           new NGFruitSourceType() { Id=53, Name="Pineapple", Brix = 14.3 },
           new NGFruitSourceType() { Id=54, Name="Plum", Brix = 14.3 },
           new NGFruitSourceType() { Id=55, Name="Pomegranate", Brix = 18.2 },
           new NGFruitSourceType() { Id=56, Name="Prune", Brix = 18.5 },
           new NGFruitSourceType() { Id=57, Name="Quince", Brix = 13.3 },
           new NGFruitSourceType() { Id=58, Name="Raisin", Brix = 18.5 },
           new NGFruitSourceType() { Id=59, Name="Red Raspberry", Brix = 10.5 },
           new NGFruitSourceType() { Id=60, Name="Red Currant", Brix = 10.5 },
           new NGFruitSourceType() { Id=61, Name="Soursop", Brix = 16.0 },
           new NGFruitSourceType() { Id=62, Name="Guanabana", Brix = 16.0 },
           new NGFruitSourceType() { Id=63, Name="Annono Muricata", Brix = 16.0 },
           new NGFruitSourceType() { Id=64, Name="Strawberry", Brix = 8.0 },
           new NGFruitSourceType() { Id=65, Name="Tamarind", Brix = 55.0 },
           new NGFruitSourceType() { Id=66, Name="Tangerine", Brix = 11.5 },
           new NGFruitSourceType() { Id=67, Name="Youngberry", Brix = 10.0 }
            };

            context.NGFruit.AddRange(fruitlist);
            context.SaveChanges();
            base.Seed(context);

        }
 
 }

    public class WineContext : DbContext
    {
    
        // ************************************************
        // ************ Initialize Database ***************
        // ************************************************

        public WineContext() : base("WineDb")
        {
            Database.SetInitializer(new MyDatabaseInitializer());

        }
        public DbSet<Wine> Wines { get; set; }
        public DbSet<GrapeVarietal> Varietals { get; set; }
        public DbSet<NGFruitSourceType> NGFruit {get; set; }
    
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        //\\\\\\\ CODE FROM STACK OVERFLOW TO TRACE DATA VALIDATION \\
        //\\\\\\\ ERRORS \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

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
    //\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
