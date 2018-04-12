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

            using (WineContext db = new WineContext())
            {

                return View(db.SliderPics.ToList());

            }
            //return View();
        }

        //Add images in slider

        public ActionResult AddImage()
        {

            using (WineContext db = new WineContext())
            {
                return View(db.SliderPics.ToList());
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
                using (WineContext db = new WineContext())
                {
                    SliderPic sliderPic = new SliderPic
                    {
                        ImageURL = "~/Content/Images/" + pic,
                        Name = pic
                    };
                    db.SliderPics.Add(sliderPic);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // Delete multiple copies of images

        public ActionResult DeleteImages()
        {
            using (WineContext db = new WineContext())
            {
                return View(db.SliderPics.ToList());
            }

        }

        [HttpPost]
        public ActionResult DeleteImages(IEnumerable<int> ImageIDs)
        {
            using (WineContext db = new WineContext())
            {
                foreach (var id in ImageIDs)
                {
                    var image = db.SliderPics.Single(s => s.Id == id);
                    string imgPath = Server.MapPath(image.ImageURL);
                    db.SliderPics.Remove(image);
                    if (System.IO.File.Exists(imgPath))
                        System.IO.File.Delete(imgPath);
                }
                db.SaveChanges();
            }
            return RedirectToAction("DeleteImages");
        }

    }
}