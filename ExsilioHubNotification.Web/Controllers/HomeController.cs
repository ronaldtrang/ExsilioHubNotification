using NLog.Fluent;
using NLog.LayoutRenderers;
using System.Web.Mvc;

namespace ExsilioHubNotification.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}