using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities;
using TaskManager.WebAPI.Controllers;
using TaskManager.BusinessLib;
using TaskManager.DataLib;
using NUnit.Framework;
using System.Web.Http;

namespace TaskManager.TestAPILayer
{
    [TestFixture]
    public class APITestCase
    {        
        public List<Entities.Task> GetTasks()
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                return db.Tasks.ToList();
            }
        }

        [Test]

        public void GetAllTask_API()
        {
            var controller = new TaskController();
            IHttpActionResult actionResult = controller.Get();
            var contentResult = actionResult;
            Assert.IsNotNull(contentResult);
        }

        [Test]

        public void AddTask_API()
        {
            TaskBL objBL = new TaskBL();
            Entities.Task ts = new Entities.Task();
            ts.TaskName = "APITest";
            ts.ParentID = "Nice";
            ts.Priority = 10;
            ts.SDate = DateTime.Now;
            ts.EDate = DateTime.Now;
            var controller = new TaskController();
            IHttpActionResult actionResult = controller.POST(ts);

        }

        [Test]
        public void UpdateTask_API()
        {
            TaskBL objBL = new TaskBL();
            Entities.Task ts = new Entities.Task();
            ts.TaskID = 2024;
            ts.TaskName = "Ankesh1";
            ts.ParentID = "Ankesh9";
            ts.Priority = 10;
            ts.SDate = DateTime.Now;
            ts.EDate = DateTime.Now;

            var controller = new TaskController();
            string actionResult = controller.Edit(ts);
            string Expected = "Task is updated";
            Assert.AreEqual(Expected.ToString(), actionResult.ToString());
        }

        [Test]
        public void DeleteTask_API()
        {
            var controller = new TaskController();
            IHttpActionResult actionResult = controller.DeleteTask(2020);
            var contentResult = actionResult;
            Assert.IsNotNull(contentResult);
        }

    }
}
