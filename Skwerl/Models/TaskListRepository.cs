using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Skwerl.Controllers;
using System.Data;
using System.Data.Entity;

namespace Skwerl.Models
{
    public class TaskListRepository : ITaskListRepository
    {

        private UsersContext _db = new UsersContext();

        public IEnumerable<TaskList> Index()
        {
            return _db.TaskLists.ToList();
        }

        public TaskList GetTaskListbyID(string id)
        {
            return _db.TaskLists.Find(id);
        }

        public void Create(TaskList tasklist)
        {
            _db.TaskLists.Add(tasklist);
            Validated.SaveIt(_db);
        }
        public TaskList Edit(string id)
        {
            return _db.TaskLists.Find(id);
           
        }
        public void Update(TaskList tasklist)
        {
            _db.Entry(tasklist).State = EntityState.Modified;
            Validated.SaveIt(_db);

        }
        public void Delete(TaskList tasklist)
        {
            _db.TaskLists.Remove(tasklist);
            Validated.SaveIt(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

    }

    public interface ITaskListRepository
    {
        IEnumerable<TaskList> Index();
        TaskList GetTaskListbyID(string id);
        void Create(TaskList tasklist);
        void Update(TaskList tasklist);
        void Delete(TaskList tasklist);
        void Dispose();

    }
}