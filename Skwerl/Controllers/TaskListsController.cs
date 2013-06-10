using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Skwerl.Models;

namespace Skwerl.Controllers
{
    public class TaskListsController : Controller
    {
        private UsersContext db = new UsersContext();

        //
        // GET: /TaskLists/

        public ActionResult ViewMaps()
        {
            return View();
        }

        public ViewResult Index()
        {
            return View(db.TaskLists.ToList());
        }

        //
        // GET: /TaskLists/Details/5

        public ActionResult Details(string id = null)
        {
            TaskList tasklist = db.TaskLists.Find(id);
            if (tasklist == null)
            {
                return HttpNotFound();
            }
            return View(tasklist);
        }

        //
        // GET: /TaskLists/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /TaskLists/Create

        [HttpPost]
        public ActionResult Create(TaskList tasklist)
        {
            if (ModelState.IsValid)
            {
                db.TaskLists.Add(tasklist);
                tasklist.ID = Guid.NewGuid().ToString();
                Validated.SaveIt(db);
                return RedirectToAction("Index");
            }

            return View(tasklist);
        }

        //
        // GET: /TaskLists/Edit/5

        public ActionResult Edit(string id = null)
        {
            TaskList tasklist = db.TaskLists.Find(id);
            if (tasklist == null)
            {
                return HttpNotFound();
            }
            return View(tasklist);
        }

        //
        // POST: /TaskLists/Edit/5

        [HttpPost]
        public ActionResult Edit(TaskList tasklist)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tasklist).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tasklist);
        }

        //
        // GET: /TaskLists/Delete/5

        public ActionResult Delete(string id = null)
        {
            TaskList tasklist = db.TaskLists.Find(id);
            if (tasklist == null)
            {
                return HttpNotFound();
            }
            return View(tasklist);
        }

        //
        // POST: /TaskLists/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            TaskList tasklist = db.TaskLists.Find(id);
            db.TaskLists.Remove(tasklist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}