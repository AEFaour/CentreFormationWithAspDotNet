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
using AutoMapper;

namespace WebApplicationGestionParcours.Controllers
{
    public class ParcoursController : Controller
    {
        private DBGestionParcoursEntities db = new DBGestionParcoursEntities();

        [HttpPost]
        public JsonResult Supprimer(int id)
        {
            Parcours parcoursASupp = db.Parcours.SingleOrDefault(p => p.Id == id);
            if (parcoursASupp.Module.ToList().Count > 0)
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

        public bool IsSloganUnique(string slogan)
        {
            var _result = (db.Parcours.Where(x => x.Slogan.Contains(slogan))).ToList(); // 

            return (_result.Count > 0);
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
        public async Task<ActionResult> Create([Bind(Include = "Id,Nom,Slogan,Logo")] ParcoursMVC parcoursMVC)
        {
            Parcours parcours = new Parcours();

            //Créer une configuration de Mapper --cas de Mappage avec classe source et dest
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ParcoursMVC, Parcours>());

            //Créer un Mapper en lui passant en param la config crée
            var mapper = new Mapper(config);
            // faire  l'affectation

            parcours = mapper.Map<Parcours>(parcoursMVC);

            if (ModelState.IsValid)
            {
                // Affecter parcoursMVC dans parcours et pour cela on utilise AutoMapper
                // parcours.Nom = parcoursMVC.Nom; // 
                db.Parcours.Add(parcours);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(parcoursMVC);
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
            // Envoyer un parcoursMVC
            ParcoursMVC parcoursMVC = new ParcoursMVC();
            var config = new MapperConfiguration(x => x.CreateMap<Parcours, ParcoursMVC>());
            var mapper = new Mapper(config);
            parcoursMVC = mapper.Map<ParcoursMVC>(parcours);
            return View(parcoursMVC);
        }

        // POST: Parcours/Edit/5
        // Pour vous protéger des attaques par survalidation, activez les propriétés spécifiques auxquelles vous souhaitez vous lier. Pour 
        // plus de détails, consultez https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nom,Slogan,Logo")] ParcoursMVC parcoursMVC)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ParcoursMVC, Parcours>());
            var mapper = new Mapper(config);

            Parcours parcours = new Parcours();
            parcours = mapper.Map<Parcours>(parcoursMVC);
            if (ModelState.IsValid)
            {
                db.Entry(parcours).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(parcoursMVC);
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
