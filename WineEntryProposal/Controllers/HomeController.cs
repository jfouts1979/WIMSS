using System;
using System.Linq;
using System.Web.Mvc;
using HtmlAgilityPack;

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
                //Console.WriteLine(db.Database);
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

            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://www.ttb.gov/foia/xls/frl-wine-producers-and-blenders-ak-to-az-and-co-to-ky.htm");

            var query = from table in doc.DocumentNode.SelectNodes("//table").Cast<HtmlNode>()
                from row in table.SelectNodes("tr").Cast<HtmlNode>()
                from cell in row.SelectNodes("th|td").Cast<HtmlNode>()
                select new { Table = table.Id, CellText = cell.InnerText };
            int i = 0;
            // Example #1: Write an array of strings to a file.
            // Create a string array that consists of three lines.
            string[] lines = new string[1316];
            foreach (var cell in query)
            {
                
                Console.WriteLine("{0}: {1}", cell.Table, cell.CellText);
                i = i++;
                lines[i] = (cell.Table+cell.CellText);
            }
            // WriteAllLines creates a file, writes a collection of strings to the file,
            // and then closes the file.  You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);

            //var secondTable = res.SelectSingleNode("//table[2]");


            return View();

        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}