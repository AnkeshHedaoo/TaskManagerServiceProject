using System;
using System.Collections.Generic;
using NBench;
using TaskManager.Entities;
using System.Web.Http;
using TaskManager.WebAPI.Controllers;


namespace TaskManager.PerformanceTest
{
    public class PerfTest
    {
        private const int AcceptableMinAddThroughput = 50;

        private static TaskController controller = new TaskController()
        {
            Request = new System.Net.Http.HttpRequestMessage(),
            Cofiguration = new HttpConfiguration()
        };
        List<Task> tasks = new List<Entities.Task>();

        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            for (var cnt = 0; cnt < 100; cnt++)
            {
                tasks.Add(new Task()
                {
                    TaskID = 10,
                    TaskName = "Performance Test",
                    ParentID = "1",
                    SDate = DateTime.Now.Date,
                    EDate = DateTime.Now.AddDays(2),
                    IsTaskEnded = false,
                    Priority = 1

                });
            }
        }

        [PerfBenchmark(NumberOfIterations = 5, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000, MinTimeMilliseconds = 1000)]

        public void AddTask_Throughput_IterationMode(BenchmarkContext context)
        {
            for (var i = 0; i < tasks.Count; i++)
            {
                IHttpActionResult result = controller.POST(tasks[i]);
            }
        }

        [PerfBenchmark(NumberOfIterations = 1, RunMode = RunMode.Throughput, TestMode = TestMode.Test, SkipWarmups = true)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 10000, MinTimeMilliseconds = 1000)]

        public void GetTask_Throughput_IterationMode(BenchmarkContext context)
        {
            for (var i = 0; i < AcceptableMinAddThroughput; i++)
            {
                IHttpActionResult result = controller.Get();
            }
        }

        [PerfCleanup]
        public void Cleanup(BenchmarkContext context)
        {

        }
    }
}
