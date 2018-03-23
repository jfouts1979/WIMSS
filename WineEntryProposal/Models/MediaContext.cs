using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace WineEntryProposal.Models
{
    //********************************************
    //*** Drop and Create the Database Only******
    //*** If the Model Changes*******************
    //********************************************

    public class MediaDatabaseInitializer : DropCreateDatabaseIfModelChanges<MediaDatabaseInitializer.MediaContext>
    {

        //**********************************************
        //*** Seed the Database With the Data Below****
        //**********************************************

        protected override void Seed(MediaContext context)
        {

            // *******************************************
            // *** Images To Populate Slider *************
            // *******************************************

            Gallery gallery = new Gallery
            {
                //need to add code here to populate slider...
            };



            context.gallery.Add(gallery);
            context.SaveChanges();
            base.Seed(context);

        }

        //*** This Portion of Code Needs To Be Modified  *************
        //*** Will Be Used To Seed The Database With Slider Images ***
        //*** On a Pre-populated basis. ******************************

        //*** The GetImage Method Will Be Used to Load Images Into ****
        //*** A Byte Array File.  The Code Is Not Yet Complete ********

        // public byte[] GetImage(string filePath)

        //{
        //    var path = Path.Combine(Server.MapPath("~/Content/Files/"), file.FileName);
        //    Image = File.ReadAllBytes("Tester1 - SeaBiscuit_800x365.jpg");
        //    fileName = "Tester1 - SeaBiscuit_800x365.jpg";
        //    return null;
        //}

        //*************************************************************
        //*************************************************************




        //public ActionResult Index()
        //{
        //    var path = Server.MapPath("~/Content/Files/");

        //    var dir = new DirectoryInfo(path);

        //    var files = dir.EnumerateFiles().Select(f => f.Name);

        //    return View(files);
        //}

        //[HttpPost]
        //public ActionResult Index(HttpPostedFileBase file)
        //{
        //    var path = Path.Combine(Server.MapPath("~/Content/Files/"), file.FileName);

        //    var data = new byte[file.ContentLength];
        //    file.InputStream.Read(data, 0, file.ContentLength);

        //    using (var sw = new FileStream(path, FileMode.Create))
        //    {
        //        sw.Write(data, 0, data.Length);
        //    }

        //    return RedirectToAction("Index");
        //}

        // ************************************************
        // ************ Initialize Database ***************
        // ************************************************

        //public MediaContext() : base("MediaContext")
        //{
        //    Database.SetInitializer(new MyDatabaseInitializer());
        //}

        //public class MediaContext : DbContext
        //{
            //public DbSet<Gallery> gallery { get; set; }
        //}

        public class MediaContext : DbContext
        {

            // ************************************************
            // ************ Initialize Database ***************
            // ************************************************

            public MediaContext() : base("MediaContext")
            {
                Database.SetInitializer(new MyDatabaseInitializer());

            }
            //public DbSet<Wine> Wines { get; set; }
            //public DbSet<GrapeVarietal> Varietals { get; set; }
            //public DbSet<NGFruitSourceType> NGFruit { get; set; }
            public DbSet<Gallery> gallery { get; set; }

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
}