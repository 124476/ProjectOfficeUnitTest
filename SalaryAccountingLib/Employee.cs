using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SalaryAccountingLib
{
    public class Employee
    {
        [JsonPropertyName("Position")]
        public string Position { get; set; }
        [JsonPropertyName("Salary")]
        public double Salary { get; set; }
        [JsonPropertyName("Tasks")]
        public List<TaskDTO> Tasks { get; set; }
        [JsonPropertyName("WorkingDays")]
        public List<WorkingDay> WorkingDays { get; set; }
    }
}
