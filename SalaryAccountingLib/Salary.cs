using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryAccountingLib
{
    public class Salary
    {
        public static double[] CalculationSalary(List<WorkingDay> workingDays, List<TaskDTO> tasks, double salary)
        {
            int dateAllWork = 0;
            int dateAllHol = 0;
            double srdmi = 400;
            double sumSickAll = 0;
            double allLastTime = 0;

            var days = workingDays.Where(x => x.Date < DateTime.Now.AddMonths(-1) && x.Date > DateTime.Now.AddMonths(-2)).ToList();
            foreach (var day in days)
            {
                allLastTime += Double.Parse(day.Hours);
            }
            if (allLastTime != 0)
            {
                srdmi = salary / allLastTime;
            }

            foreach (var item in workingDays)
            {
                if (item.Hours != null && item.Hours != "0")
                {
                    continue;
                }
                if (item.Status == StatusDay.PreWorking)
                {
                    dateAllHol += Int32.Parse(item.Hours);
                }
                if (item.Status == StatusDay.Working)
                {
                    dateAllWork += Int32.Parse(item.Hours);
                }
                if (item.Status == StatusDay.SickLeave)
                {
                    dateAllWork += 8;
                    sumSickAll += srdmi;
                }
            }
            int otgylAll = 0;
            int dateAll = dateAllHol + dateAllWork;
            double sumAll = 0.02 * dateAllHol * salary;
            if (dateAllWork > 40)
            {
                sumAll += (dateAllWork - 40) * 0.02 * salary;
            }

            if (sumAll > 0.6 * salary)
            {
                sumAll = 0.6 * salary;
                int dateLast = dateAll - 70;
                otgylAll = dateLast / 8;
            }

            sumAll += salary;
            Double shtraf = 0;
            foreach (var item in tasks)
            {
                if (item.FinishActualTime < item.Deadline)
                    sumAll += 0.02 * salary;
                else
                {
                    sumAll -= 0.01 * (item.FinishActualTime - item.Deadline).Days * salary;
                    shtraf += 0.01 * (item.FinishActualTime - item.Deadline).Days * salary;
                };
            }

            if (sumAll < 16242)
            {
                sumAll = 16242;
            }

            Double primia = 0;
            if (sumAll > salary)
            {
                primia = sumAll - salary;
            }

            return new double[] { sumAll, primia, Int32.Parse((shtraf * 10000).ToString()) / 10000, sumSickAll, otgylAll };
        }
    }
}
