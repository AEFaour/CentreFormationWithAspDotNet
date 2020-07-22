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
    public class RealisationsController : Controller
    {
        private DBGestionParcoursEntities db = new DBGestionParcoursEntities();

        // GET: Realisations
        public async Task<ActionResult> Index()
        {
            var realisation = db.Realisation.Include(r => r.Module);
            return View(await realisation.ToListAsync());
        }

        // GET: Realisations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realisation realisation = await db.Realisation.FindAsync(id);
            if (realisation == null)
            {
                return HttpNotFound();
            }
            return View(realisation);
        }

        // GET: Realisations/Create
        public ActionResult Create()
        {
            ViewBag.IdModule = new SelectList(db.Module, "Id", "Libelle");
            return View();
        }

        // POST: Realisations/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,IdModule,DateDebut,DateFin,Info")] Realisation realisation)
        {
            if (ModelState.IsValid)
            {
                db.Realisation.Add(realisation);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdModule = new SelectList(db.Module, "Id", "Libelle", realisation.IdModule);
            return View(realisation);
        }

        // GET: Realisations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realisation realisation = await db.Realisation.FindAsync(id);
            if (realisation == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdModule = new SelectList(db.Module, "Id", "Libelle", realisation.IdModule);
            return View(realisation);
        }

        // POST: Realisations/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IdModule,DateDebut,DateFin,Info")] Realisation realisation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(realisation).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdModule = new SelectList(db.Module, "Id", "Libelle", realisation.IdModule);
            return View(realisation);
        }

        // GET: Realisations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Realisation realisation = await db.Realisation.FindAsync(id);
            if (realisation == null)
            {
                return HttpNotFound();
            }
            return View(realisation);
        }

        // POST: Realisations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Realisation realisation = await db.Realisation.FindAsync(id);
            db.Realisation.Remove(realisation);
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
