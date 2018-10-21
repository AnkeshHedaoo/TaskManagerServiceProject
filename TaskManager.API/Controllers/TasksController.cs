//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web.Http;
//using System.Web.Http.Description;
//using TaskManager.BusinessLib;
//using TaskManager.DataLib;
//using TaskManager.Entities;

//namespace TaskManager.API.Controllers
//{
//    public class TasksController : ApiController
//    {
//        private TaskManagerContext db = new TaskManagerContext();
//        TaskBL businessData = new TaskBL();

//        public List<Entities.Task> GetTasks()
//        {
//            return businessData.GetAll();
//        }

//        [ResponseType(typeof(Entities.Task))]
//        public async Task<IHttpActionResult>GetTask(int id)
//        {
//            Entities.Task task = await businessData.GetById(id);
//            if(task==null)
//            { return NotFound(); }
//            return Ok(task);

//        }

//        [ResponseType(typeof(void))]
//        public async Task<IHttpActionResult> PutTask(int id , Entities.Task task)
//        {
//            if(!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            if(id!=task.TaskID)
//            {
//                return BadRequest();
//            }
//            try
//            {
//                string s = await businessData.UpdateTask(task);
//                if (s == "Task Not Found")
//                    return NotFound();
//                return Ok(s);
//            }
//            catch(DbUpdateConcurrencyException)
//            {
//                if(!TaskExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }
//        }

//        private bool TaskExists(int id)
//        {
//            return db.Tasks.Count(e => e.TaskID == id) > 0;
//        }

//        [ResponseType(typeof(Entities.Task))]
//        public async Task<IHttpActionResult> PostTask(Entities.Task task)
//        {
//            if(!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            businessData.Add(task);
//            return CreatedAtRoute("DefaultApi", new { id = task.TaskID }, task);
//        }

//        [ResponseType(typeof(Entities.Task))]
//        public async Task<IHttpActionResult>DeleteTask(int id)
//        {
//            Entities.Task task = await db.Tasks.FindAsync(id);
//            if(task == null)
//            {
//                return NotFound();
//            }
//            db.Tasks.Remove(task);
//            await db.SaveChangesAsync();
//            return Ok(task);
//        }
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();

//            }
//            base.Dispose(disposing);
//        }
//    }
//}
