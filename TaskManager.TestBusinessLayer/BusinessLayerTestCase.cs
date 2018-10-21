using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TaskManager.BusinessLib;
using TaskManager.Entities;


namespace TaskManager.TestBusinessLayer
{
    [TestFixture]
    public class BusinessLayerTestCase
    {
        [Test]
        public void TestGetAllTask_BL()
        {
            TaskBL objBL = new TaskBL();
            int count = objBL.GetAll().Count;
            Assert.Greater(count, 0);
        }

        [Test]
        public void TestAddTask_BL()
        {
            TaskBL objBAL = new TaskBL();
            objBAL.AddTask(new Entities.Task()
            {
                TaskName = "Test123",
                ParentID ="Ankesh1",
                Priority = 11,
                SDate = DateTime.Now,
                EDate = DateTime.Now,
                IsTaskEnded = false

            });
            string expected = "Test123";
            string actual = objBAL.GetTaskByName("Test123").TaskName;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestUpdateTask_BL()
        {
            TaskBL objBL = new TaskBL();
            objBL.Update(new Entities.Task()
            {
                TaskID = 2024,
                TaskName = "Ankesh9",
                ParentID="Ankesh",
                Priority = 11,
                SDate = DateTime.Now,
                EDate = DateTime.Now

            }
            );
            string expected = "Task1";
            string actual = objBL.GetTaskByName("Task1").TaskName;
            Assert.AreEqual(expected, actual);
           
        }

        [Test]
        public void TestDeleteTask_BL()
        {
            string actual = "";
            string e = "";
            string expected = "";

            try
            {
                TaskBL objBL = new TaskBL();
                objBL.DeleteTaskById(2023);
                List<Entities.Task> tasks = objBL.GetAll().ToList();
                CollectionAssert.DoesNotContain(tasks, 2025);

            }
            catch(NullReferenceException ex)
            {
                e = ex.Message;
                expected = "";

            }
            finally
            {
                Assert.AreEqual(expected, actual.ToString());
            }
        }
    }
}
