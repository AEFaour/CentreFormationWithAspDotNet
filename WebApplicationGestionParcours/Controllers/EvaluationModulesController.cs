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
    public class EvaluationModulesController : Controller
    {
        private DBGestionParcoursEntities db = new DBGestionParcoursEntities();

        // GET: EvaluationModules
        public async Task<ActionResult> Index()
        {
            var evaluationModule = db.EvaluationModule.Include(e => e.Module);
            return View(await evaluationModule.ToListAsync());
        }

        // GET: EvaluationModules/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvaluationModule evaluationModule = await db.EvaluationModule.FindAsync(id);
            if (evaluationModule == null)
            {
                return HttpNotFound();
            }
            return View(evaluationModule);
        }

        // GET: EvaluationModules/Create
        public ActionResult Create()
        {
            ViewBag.IdModule = new SelectList(db.Module, "Id", "Libelle");
            return View();
        }

        // POST: EvaluationModules/Create
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,IdModule,DateEvaluation,Source,Note,Info")] EvaluationModule evaluationModule)
        {
            if (ModelState.IsValid)
            {
                db.EvaluationModule.Add(evaluationModule);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdModule = new SelectList(db.Module, "Id", "Libelle", evaluationModule.IdModule);
            return View(evaluationModule);
        }

        // GET: EvaluationModules/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvaluationModule evaluationModule = await db.EvaluationModule.FindAsync(id);
            if (evaluationModule == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdModule = new SelectList(db.Module, "Id", "Libelle", evaluationModule.IdModule);
            return View(evaluationModule);
        }

        // POST: EvaluationModules/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IdModule,DateEvaluation,Source,Note,Info")] EvaluationModule evaluationModule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluationModule).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdModule = new SelectList(db.Module, "Id", "Libelle", evaluationModule.IdModule);
            return View(evaluationModule);
        }

        // GET: EvaluationModules/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvaluationModule evaluationModule = await db.EvaluationModule.FindAsync(id);
            if (evaluationModule == null)
            {
                return HttpNotFound();
            }
            return View(evaluationModule);
        }

        // POST: EvaluationModules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            EvaluationModule evaluationModule = await db.EvaluationModule.FindAsync(id);
            db.EvaluationModule.Remove(evaluationModule);
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
