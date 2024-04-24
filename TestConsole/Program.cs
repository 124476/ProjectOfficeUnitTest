using SalaryAccountingLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
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
             
            double[] doubles = Salary.CalculationSalary(workDays, tasks, 20000);
            Console.WriteLine(doubles[0]);
            Console.WriteLine(doubles[1]);
            Console.WriteLine(doubles[2]);
            Console.WriteLine(doubles[3]);
            Console.WriteLine(doubles[4]);
            Console.ReadLine();
        }
    }
}
