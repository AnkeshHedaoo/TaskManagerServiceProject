using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace TaskManager.DataLib
{
    public class DataBaseInitializer : DropCreateDatabaseIfModelChanges<TaskManagerContext>
    {
        protected override void Seed(TaskManagerContext context)
        {
            base.Seed(context);

            Entities.Task tsk = new Entities.Task
            {
                Priority = 1,
                SDate = DateTime.Now.Date,
                TaskName = "Ankesh Task"

            };
            Entities.Task tsk1 = new Entities.Task
            {
                Priority = 2,
                SDate = DateTime.Now.Date,
                TaskName = "Ankesh11 Task"

            };
            context.Tasks.Add(tsk1);
            context.SaveChanges();
        }
    }
}
