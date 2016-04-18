using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using ChainOfResponsibility.Core.Validators.ApartmentBooking;
using ChainOfResponsibility.Models;

namespace ChainOfResponsibility.Controllers
{
    public class ApartmentBookingController : Controller
    {
        private MyDataContext db = new MyDataContext();

        // GET: /Home/
        public async Task<ActionResult> Index()
        {
            return View(await db.ApartmentBookings.ToListAsync());
        }

        public ActionResult Create()
        {
            return View(new ApartmentBooking() { DateFrom = DateTime.Now, DateTo = DateTime.Now.AddDays(2) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ApartmentBooking model)
        {
            //if (ModelState.IsValid)
            {
                var errorsResult = ApartmentBookingValidationContext.Validate(model);
                if (errorsResult.Any())
                {
                    ModelState.Clear();

                    foreach (var error in errorsResult)
                    {
                        ModelState.AddModelError(error.Key, error.Value);
                    }
                    TempData["ValidationErrors"] = true;

                    return View(model);
                }
                else
                {
                    db.ApartmentBookings.Add(model);
                    await db.SaveChangesAsync();
                }

                return RedirectToAction("Index");
            }

            //return View(model);
        }

        // GET: /Home/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApartmentBooking model = await db.ApartmentBookings.FindAsync(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ApartmentBooking mydata = await db.ApartmentBookings.FindAsync(id);
            db.ApartmentBookings.Remove(mydata);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
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