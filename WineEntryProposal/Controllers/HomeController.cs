using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

namespace WineEntryProposal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //using (WineContext db = new WineContext())
            //{
            //    return View(db.sliderPics.ToList());
            //    //return View();
            //}

            // *************************************************
            // *** Establish New WineContext (Plate of Data) ***
            // *** And Return the list of wine *****************
            // *************************************************

            using (WineContext db = new WineContext())
            {
                //var x = context.SliderPics.Include(g => g.SliderPic).ToList();
                return View(db.SliderPics.ToList());
                //return View("Index", x);
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "A Solution For Ever Changing Needs In the Industries Administered By Local, State, and Federal ATC, ABC, Liquor Control Boards, and the Federal Tax and Trade Bureau (TTB). .";


            //List<Country> objCountry = new List<Country>();
            //CountryModel model = new CountryModel();
            //objCountry = model.GetCountries();
            //return View(new Venue { Countries = objCountry });

            return View();

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}