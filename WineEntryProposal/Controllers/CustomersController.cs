using System.Web.Mvc;

namespace WineEntryProposal.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {   
        // GET: Customer
        public ActionResult Index()

        {
            return View();
        }
    }
}
