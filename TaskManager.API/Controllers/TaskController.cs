using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManager.Entities;
using System.Threading.Tasks;
using TaskManager.BusinessLib;
using System.Web.Http.Description;
using System.Data.Entity.Infrastructure;

namespace TaskManager.WebAPI.Controllers
{
    public class TaskController : ApiController
    {
        TaskBL taskobj = new TaskBL();

        public new HttpRequestMessage Request { get; set; }
        public HttpConfiguration Cofiguration { get; set; }

        [Route ("GetAllTask")]
        public IHttpActionResult Get()
        {
            return Ok(taskobj.GetAll());
        }


        [Route("GetTaskById/{id:int}")]
        [HttpGet]
        [ResponseType(typeof(Entities.Task))]
        public async Task<IHttpActionResult> Get(int id)
        {
            Entities.Task task = await taskobj.GetById(id);
            if(task == null)
            {
                //return this.NotFound();
                return Ok("Task Not Found");
            }
            return Ok(task);

        }
   
        [Route("UpdateTaskById/{id:int}")]

        [ResponseType(typeof(Entities.Task))]
        [HttpPut]
        public async Task<IHttpActionResult> PUT(int id, Entities.Task task)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id!=task.TaskID)
            {
                return BadRequest();
            }
            string result = await taskobj.UpdateTask(task);
            if (result == "Task Not Found")
                return NotFound();
            return Ok(result);
        }
        
        [Route("AddTask")]
        [ResponseType(typeof(Entities.Task))]
        [HttpPost]
        public async Task<IHttpActionResult> Post(Entities.Task task)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await taskobj.Add(task);
            return Ok("Task Added Successfully");
        }

        [Route("DeleteTaskById/{id:int}")]
        [ResponseType(typeof(Entities.Task))]
        public async Task<IHttpActionResult> Delete(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //if(id!=task.TaskID)
            //{
            //    return BadRequest();
            //}
            string result = await taskobj.DeleteTask(id);
            if (result == "Task Not Found")
                return NotFound();
            return Ok(result);
        }

        [Route("EndTaskById/{id:int}")]
        [ResponseType(typeof(void))]
        [ResponseType(typeof(Entities.Task))]
        public async Task<IHttpActionResult> Put(int id)
        {
            Entities.Task task = new Entities.Task();
            task.TaskID = id;
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            string result = await taskobj.EndTask(task);
            if (result == "Task Not Found")
                return NotFound();
            return Ok(result);
        }

        //Testing Purpose

        public IHttpActionResult POST(Entities.Task task)
        {
            TaskBL obj = new TaskBL();
            obj.AddTask(task);
            return Ok("Task is Added");
        }

        public string Edit(Entities.Task task)
        {
            TaskBL obj = new TaskBL();
            obj.Update(task);
            return "Task is updated";
        }

        public IHttpActionResult DeleteTask(int Id)
        {
            TaskBL obj = new TaskBL();
            obj.DeleteTaskById(Id);
            return Ok("Task Is Deleted");
        }
    }
}
