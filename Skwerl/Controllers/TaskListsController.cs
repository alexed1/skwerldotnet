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
        // private UsersContext db = new UsersContext();
        public ITaskListRepository _repository;

        public TaskListsController() : this(new TaskListRepository()) { }



        //
        // GET: /TaskLists/
        public TaskListsController(ITaskListRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            return View(_repository.Index());
        }

        //
        // GET: /TaskLists/Details/5

        public ActionResult Details(string id = null)
        {
            TaskList tasklist = _repository.GetTaskListbyID(id); //db.TaskLists.Find(id);
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
                tasklist.ID = Guid.NewGuid().ToString();
                _repository.Create(tasklist);
                return RedirectToAction("Index");
            }

            return View(tasklist);
        }

        //
        // GET: /TaskLists/Edit/5

        public ActionResult Edit(string id = null)
        {
            TaskList tasklist = _repository.GetTaskListbyID(id);
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
                _repository.Update(tasklist);
                return RedirectToAction("Index");
            }
            return View(tasklist);
        }

        //
        // GET: /TaskLists/Delete/5

        public ActionResult Delete(string id = null)
        {
            TaskList tasklist = _repository.GetTaskListbyID(id);
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
            TaskList tasklist = _repository.GetTaskListbyID(id);
            _repository.Delete(tasklist);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }

    }
}