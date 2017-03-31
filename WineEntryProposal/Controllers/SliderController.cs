using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WineEntryProposal.Models;

namespace WineEntryProposal.Controllers
{
    public class SliderController : Controller
    {
        // GET: Slider
        public ActionResult Index()
        {

            using (MediaContext db = new MediaContext())
            {

                return View(db.gallery.ToList());

            }
            // return View();
        }

        // Add images in slider

        public ActionResult AddImage()
        {

            using (MediaContext db = new MediaContext())
            {
                return View(db.gallery.ToList());
            }
            //return View();
        }

        [HttpPost]
        public ActionResult AddImage(HttpPostedFileBase ImagePath)
        {
            if (ImagePath != null)
            {
                // This forces user to upload images of 
                // specified resolution.
                System.Drawing.Image img = System.Drawing.Image.FromStream(ImagePath.InputStream);
                                
                if ((img.Width != 800 && img.Height != 356))
                {
                    ModelState.AddModelError("", "Image resolution must be 800 x 356 pixels.");
                    return View();
                }

                // Upload pic
                string pic = System.IO.Path.GetFileName(ImagePath.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Content/Images/"), pic);
                ImagePath.SaveAs(path);
                using (MediaContext db = new MediaContext())
                {
                    Gallery gallery = new Gallery { ImagePath = "~/Content/Images/" + pic };
                    db.gallery.Add(gallery);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // Delete multiple copies of images

        public ActionResult DeleteImages()
        {
            using (MediaContext db = new MediaContext())
            {
                return View(db.gallery.ToList());
            }

        }

        [HttpPost]
        public ActionResult DeleteImages(IEnumerable<int> ImagesIDs)
        {
            using (MediaContext db = new MediaContext())
            {
                foreach (var id in ImagesIDs)
                {
                    var image = db.gallery.Single(s => s.ID == id);
                    string imgPath = Server.MapPath(image.ImagePath);
                    db.gallery.Remove(image);
                    if (System.IO.File.Exists(imgPath))
                        System.IO.File.Delete(imgPath);
                }
                db.SaveChanges();
            }
            return RedirectToAction("DeleteImages");
        }

    }
}