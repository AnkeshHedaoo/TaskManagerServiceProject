using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskManager.DataLib;
using NUnit.Framework;
using System.Threading.Tasks;
using TaskManager.Entities;
using System.Data.Entity;

namespace TaskManager.BusinessLib
{
    public class TaskBL
    {
        public List<Entities.Task> GetAll()
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                return db.Tasks.ToList();
            };
        }

        public async Task<string> Add(Entities.Task item)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                try
                {
                    db.Tasks.Add(item);
                    await db.SaveChangesAsync();
                    return "Task Added Successfully";

                }
                catch (Exception ex)
                {
                    return "Error Adding the task";
                }
            };

        }



        //public async Task<string> AddTask(Entities.Task item)
        //{
        //    using (TaskManagerContext db = new TaskManagerContext())
        //    {
        //        try
        //        {
        //            db.Tasks.Add(item);
        //            await db.SaveChangesAsync();
        //            return "Task Added Successfully";
        //        }
        //        catch (Exception ex)
        //        {
        //            return "Error Adding Task";
        //        }
        //    };
        //}   
        public async Task<Entities.Task> GetById(int id)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                return await db.Tasks.FindAsync(id);
            };

        }

        public async Task<string> DeleteTask(int id)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                var TaskResult = db.Tasks.Where(k => k.TaskID == id).FirstOrDefault();
                if (TaskResult == null)
                    return "Task Not Found";
                db.Tasks.Remove(TaskResult);
                await db.SaveChangesAsync();
                return "Task Deleted Successfully";

            };

        }
        //public void Delete(int id)
        //{
        //    using (TaskManagerContext db = new TaskManagerContext())
        //    {
        //        var Task = db.Tasks.Where(k => k.TaskID == id).First();
        //        db.Tasks.Remove(Task);
        //        db.SaveChanges();
        //    }
        //}
        public async Task<string> UpdateTask(Entities.Task tsk)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                var TaskResult = db.Tasks.Where(k => k.TaskID == tsk.TaskID).FirstOrDefault();
                if (TaskResult == null)
                    return "Task Not Found";
                TaskResult.TaskName = tsk.TaskName;
                TaskResult.Priority = tsk.Priority;
                TaskResult.SDate = tsk.SDate;
                TaskResult.EDate = tsk.EDate;
                TaskResult.ParentID = tsk.ParentID;
                await db.SaveChangesAsync();
                return "Task Updated Successfully";

            };
        }
        public async Task<string> EndTask(Entities.Task task)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                var TaskResult = db.Tasks.Where(k => k.TaskID == task.TaskID).FirstOrDefault();
                if (TaskResult == null)
                    return "Task Not Found";
                //TaskResult.EDate = task.EDate;
                TaskResult.IsTaskEnded = true;
                await db.SaveChangesAsync();
                db.SaveChanges();
                return "Task Ended Successfully";
            };
        }


        //Testing Purpose

        public void AddTask(Entities.Task task)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                db.Tasks.Add(task);
                db.SaveChanges();
            }
        }

        public Entities.Task GetTaskByName(string name)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                return db.Tasks.SingleOrDefault(k => k.TaskName == name);
            }
        }

        public Entities.Task Update(Entities.Task task)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return task;

            }
        }

        public void DeleteTaskById(int Id)
        {
            using (TaskManagerContext db = new TaskManagerContext())
            {
                Entities.Task ts = db.Tasks.Find(Id);
                db.Tasks.Remove(ts);
                db.SaveChanges();
            }
        }
    }

}