using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AISLTP.Models.Sp;

namespace AISLTP.Controllers.Sp
{
    public class Sp_courtController : Controller
    {
        private Sp_Context db = new Sp_Context();

        // GET: Sp_court
        public async Task<ActionResult> Index()
        {
            return View(await db.Sp_courts.ToListAsync());
        }

        // GET: Sp_court/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sp_court sp_court = await db.Sp_courts.FindAsync(id);
            if (sp_court == null)
            {
                return HttpNotFound();
            }
            return View(sp_court);
        }

        // GET: Sp_court/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sp_court/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Id_parent,Dvi,Dvi_edit,Is_del,Txt,Tel,Index,Prim")] Sp_court sp_court)
        {
            if (ModelState.IsValid)
            {
                sp_court.Id_parent = 1;
                sp_court.Dvi = DateTime.Now;
                sp_court.Dvi_edit = DateTime.Now;
                sp_court.Is_del = 0;
                db.Sp_courts.Add(sp_court);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sp_court);
        }

        // GET: Sp_court/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sp_court sp_court = await db.Sp_courts.FindAsync(id);
            if (sp_court == null)
            {
                return HttpNotFound();
            }
            return View(sp_court);
        }

        // POST: Sp_court/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Id_parent,Dvi,Dvi_edit,Is_del,Txt,Tel,Index,Prim" )] Sp_court sp_court)
        {
            if (ModelState.IsValid)
            {
                sp_court.Id_parent = 1;
                sp_court.Dvi_edit = DateTime.Now;
                sp_court.Is_del = 0;
                db.Entry(sp_court).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sp_court);
        }

        // GET: Sp_court/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sp_court sp_court = await db.Sp_courts.FindAsync(id);
            if (sp_court == null)
            {
                return HttpNotFound();
            }
            return View(sp_court);
        }

        // POST: Sp_court/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Sp_court sp_court = await db.Sp_courts.FindAsync(id);
            sp_court.Id_parent = 1;
            sp_court.Dvi_edit = DateTime.Now;
            sp_court.Is_del = 1;
            db.Entry( sp_court ).State = EntityState.Modified;
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
