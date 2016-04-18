using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.Controllers
{
    public class HomeController : Controller
    {
        private MyDataContext db = new MyDataContext();

        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
