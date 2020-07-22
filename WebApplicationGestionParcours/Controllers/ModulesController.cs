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
    public class ModulesController : Controller
    {
        private DBGestionParcoursEntities db = new DBGestionParcoursEntities();

        public ActionResult Modules(int id)
        {
            List<Module> _liste = db.Module.Where(x => x.idParcours == id).ToList();
            return PartialView("_ListeModules", _liste);
        }

        // GET: Modules
        public async Task<ActionResult> Index()
        {
            var module = db.Module.Include(m => m.Parcours);
            return View(await module.ToListAsync());
        }

        // GET: Modules/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = await db.Module.FindAsync(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // GET: Modules/Create
        public ActionResult Create()
        {
            ViewBag.idParcours = new SelectList(db.Parcours, "Id", "Nom");
            return View();
        }

        // POST: Modules/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,idParcours,Libelle,NoteActuelle,DateDerniereEval,Logo,infos")] Module module)
        {
            if (ModelState.IsValid)
            {
                db.Module.Add(module);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idParcours = new SelectList(db.Parcours, "Id", "Nom", module.idParcours);
            return View(module);
        }

        // GET: Modules/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = await db.Module.FindAsync(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            ViewBag.idParcours = new SelectList(db.Parcours, "Id", "Nom", module.idParcours);
            return View(module);
        }

        // POST: Modules/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,idParcours,Libelle,NoteActuelle,DateDerniereEval,Logo,infos")] Module module)
        {
            if (ModelState.IsValid)
            {
                db.Entry(module).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idParcours = new SelectList(db.Parcours, "Id", "Nom", module.idParcours);
            return View(module);
        }

        // GET: Modules/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Module module = await db.Module.FindAsync(id);
            if (module == null)
            {
                return HttpNotFound();
            }
            return View(module);
        }

        // POST: Modules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Module module = await db.Module.FindAsync(id);
            db.Module.Remove(module);
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
