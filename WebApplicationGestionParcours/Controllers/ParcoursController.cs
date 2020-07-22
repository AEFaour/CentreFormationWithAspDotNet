using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationGestionParcours.Models;

namespace WebApplicationGestionParcours.Controllers
{
    public class ParcoursController : Controller
    {
        private DBGestionParcoursEntities db = new DBGestionParcoursEntities();

        [HttpPost]
        public JsonResult Supprimer(int id)
        {
            Parcours parcoursASupp = db.Parcours.SingleOrDefault(p => p.Id == id);
            if (parcoursASupp.Module.Count > 0)
            {
                return Json(new { Suppression = "Non" });
            }

            db.Parcours.Remove(parcoursASupp);
            db.SaveChanges();

            return Json(new { Suppression = "Ok" });
        }

        public ActionResult Parcours()
        {
            // Passer les 3 parcours phares
            return PartialView("_ListeParcours", db.Parcours.Take(3).ToList());
        }
        // GET: Parcours
        public async Task<ActionResult> Index()
        {
            return View(await db.Parcours.ToListAsync());
        }
        public async Task<ActionResult> ListeGridMVC()
        {
            return View(await db.Parcours.ToListAsync());
        }

        // GET: Parcours/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parcours parcours = await db.Parcours.FindAsync(id);
            if (parcours == null)
            {
                return HttpNotFound();
            }
            return View(parcours);
        }

        // GET: Parcours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parcours/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nom,Slogan,Logo")] Parcours parcours)
        {
            if (ModelState.IsValid)
            {
                db.Parcours.Add(parcours);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(parcours);
        }

        // GET: Parcours/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parcours parcours = await db.Parcours.FindAsync(id);
            if (parcours == null)
            {
                return HttpNotFound();
            }
            return View(parcours);
        }

        // POST: Parcours/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nom,Slogan,Logo")] Parcours parcours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parcours).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(parcours);
        }

        // GET: Parcours/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parcours parcours = await db.Parcours.FindAsync(id);
            if (parcours == null)
            {
                return HttpNotFound();
            }
            return View(parcours);
        }

        // POST: Parcours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Parcours parcours = await db.Parcours.FindAsync(id);
            db.Parcours.Remove(parcours);
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
