using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalaryAccountingLib;
using System;
using System.Collections.Generic;

namespace UnitTestProj
{
    [TestClass]
    public class SalaryUnitTest
    {
        [TestMethod]
        public void TestWithShtraftsOne()
        {
            var workDays = new List<WorkingDay>() { };

            var dateNow = DateTime.Now;
            DateTime dateTime = dateNow.AddMonths(-1);
            while (dateTime != dateNow)
            {
                dateTime = dateTime.AddDays(1);
                if (dateTime.DayOfWeek == DayOfWeek.Sunday || dateTime.DayOfWeek == DayOfWeek.Saturday)
                {
                    workDays.Add(new WorkingDay() { Hours = "0", Status = StatusDay.PreWorking, Date = dateTime });
                    continue;
                }
                workDays.Add(new WorkingDay() { Hours = "8", Status = StatusDay.Working, Date = dateTime });
            }

            var tasks = new List<TaskDTO>();
            tasks.Add(new TaskDTO() { Deadline = dateNow, FinishActualTime = dateNow.AddDays(5), FullTitle = "Разработка игры" });

            var excepted = new double[] { 95000, 0, 5000, 0, 0 };
            var actual = Salary.CalculationSalary(workDays, tasks, 100000);
            Assert.AreEqual((excepted[0], excepted[1], excepted[2], excepted[3], excepted[4]), (actual[0], actual[1], actual[2], actual[3], actual[4]));
        }

        [TestMethod]
        public void TestWithPreDays()
        {
            var workDays = new List<WorkingDay>() { };

            var dateNow = DateTime.Now;
            DateTime dateTime = dateNow.AddMonths(-1);
            while (dateTime != dateNow)
            {
                dateTime = dateTime.AddDays(1);
                if (dateTime.DayOfWeek == DayOfWeek.Sunday || dateTime.DayOfWeek == DayOfWeek.Saturday)
                {
                    workDays.Add(new WorkingDay() { Hours = "3", Status = StatusDay.PreWorking, Date = dateTime });
                    continue;
                }
                workDays.Add(new WorkingDay() { Hours = "8", Status = StatusDay.Working, Date = dateTime });
            }

            var tasks = new List<TaskDTO>();
            tasks.Add(new TaskDTO() { Deadline = dateNow, FinishActualTime = dateNow.AddDays(-4), FullTitle = "Разработка сайта" });

            var excepted = new double[] { 102000, 2000, 0, 0, 0 };
            var actual = Salary.CalculationSalary(workDays, tasks, 100000);
            Assert.AreEqual((excepted[0], excepted[1], excepted[2], excepted[3], excepted[4]), (actual[0], actual[1], actual[2], actual[3], actual[4]));
        }

        [TestMethod]
        public void TestWithWorking3Month()
        {
            var workDays = new List<WorkingDay>() { };

            var dateNow = DateTime.Now;
            DateTime dateTime = dateNow.AddMonths(-3);
            while (dateTime != dateNow)
            {
                dateTime = dateTime.AddDays(1);
                if (dateTime.DayOfWeek == DayOfWeek.Sunday)
                {
                    workDays.Add(new WorkingDay() { Hours = "0", Status = StatusDay.PreWorking, Date = dateTime });
                    continue;
                }
                if (dateTime.DayOfWeek == DayOfWeek.Monday)
                {
                    workDays.Add(new WorkingDay() { Hours = "б", Status = StatusDay.Working, Date = dateTime });
                    continue;
                }
                workDays.Add(new WorkingDay() { Hours = "7", Status = StatusDay.Working, Date = dateTime });
            }

            var tasks = new List<TaskDTO>();
            tasks.Add(new TaskDTO() { Deadline = dateNow, FinishActualTime = dateNow.AddDays(-1), FullTitle = "Разработка игры" });

            var excepted = new double[] { 102000, 2000, 0, 0, 0 };
            var actual = Salary.CalculationSalary(workDays, tasks, 100000);
            Assert.AreEqual((excepted[0], excepted[1], excepted[2], excepted[3], excepted[4]), (actual[0], actual[1], actual[2], actual[3], actual[4]));
        }
        [TestMethod]
        public void TestWithWorkingOne()
        {
            var workDays = new List<WorkingDay>() { };

            var dateNow = DateTime.Now;
            DateTime dateTime = dateNow.AddDays(-14);
            while (dateTime != dateNow)
            {
                dateTime = dateTime.AddDays(1);
                if (dateTime.DayOfWeek == DayOfWeek.Sunday)
                {
                    workDays.Add(new WorkingDay() { Hours = "б", Status = StatusDay.PreWorking, Date = dateTime });
                    continue;
                }
                workDays.Add(new WorkingDay() { Hours = "8", Status = StatusDay.Working, Date = dateTime });
            }

            var tasks = new List<TaskDTO>();
            tasks.Add(new TaskDTO() { Deadline = dateNow, FinishActualTime = dateNow.AddDays(-1), FullTitle = "Разработка игры" });

            var excepted = new double[] { 102000, 2000, 0, 0, 0 };
            var actual = Salary.CalculationSalary(workDays, tasks, 100000);
            Assert.AreEqual((excepted[0], excepted[1], excepted[2], excepted[3], excepted[4]), (actual[0], actual[1], actual[2], actual[3], actual[4]));
        }

        [TestMethod]
        public void TestWithAllShtrafts()
        {
            var workDays = new List<WorkingDay>() { };

            var dateNow = DateTime.Now;
            DateTime dateTime = dateNow.AddDays(-21);
            while (dateTime != dateNow)
            {
                dateTime = dateTime.AddDays(1);
                if (dateTime.DayOfWeek == DayOfWeek.Sunday)
                {
                    workDays.Add(new WorkingDay() { Hours = "б", Status = StatusDay.PreWorking, Date = dateTime });
                    continue;
                }
                workDays.Add(new WorkingDay() { Hours = "8", Status = StatusDay.Working, Date = dateTime });
            }

            var tasks = new List<TaskDTO>();
            tasks.Add(new TaskDTO() { Deadline = dateNow, FinishActualTime = dateNow.AddDays(14), FullTitle = "Разработка сайта" });
            tasks.Add(new TaskDTO() { Deadline = dateNow, FinishActualTime = dateNow.AddDays(14), FullTitle = "Разработка игры" });
            tasks.Add(new TaskDTO() { Deadline = dateNow, FinishActualTime = dateNow.AddDays(14), FullTitle = "Разработка приложения" });

            var excepted = new double[] { 16242, 0, 8400, 0, 0 };
            var actual = Salary.CalculationSalary(workDays, tasks, 20000);
            Assert.AreEqual((excepted[0], excepted[1], excepted[2], excepted[3], excepted[4]), (actual[0], actual[1], actual[2], actual[3], actual[4]));
        }
    }
}
