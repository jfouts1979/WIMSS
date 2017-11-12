using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;


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



            context.gallery.Add(gallery);
            context.SaveChanges();
            base.Seed(context);

        }

        //*** This Portion of Code Needs To Be Modified  *************
        //*** Will Be Used To Seed The Database With Slider Images ***
        //*** On a Pre-populated basis. ******************************

        //*** The GetImage Method Will Be Used to Load Images Into ****
        //*** A Byte Array File.  The Code Is Not Yet Complete ********

        // public byte[] GetImage (string filePath) 

        // {
        // var path = Path.Combine(Server.MapPath("~/Content/Files/"), file.FileName);
        // Image = File.ReadAllBytes("Tester1 - SeaBiscuit_800x365.jpg");
        // fileName = "Tester1 - SeaBiscuit_800x365.jpg";
        //          return null;
        // }

        //*************************************************************
        //*************************************************************




        // public ActionResult Index()
        // {
        //     var path = Server.MapPath("~/Content/Files/");
        //
        //     var dir = new DirectoryInfo(path);
        //
        //     var files = dir.EnumerateFiles().Select(f => f.Name);
        //
        //     return View(files);
        // }

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
    }



    public class MediaContext : IdentityDbContext<AppUser>
    {
        public DbSet<Gallery> gallery { get; set; }
    }
}