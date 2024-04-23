using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SalaryAccountingLib
{
    public class TaskDTO
    {
        [JsonPropertyName("FullTitle")]
        public string FullTitle { get; set; }
        [JsonPropertyName("Deadline")]
        public DateTime Deadline { get; set; }
        [JsonPropertyName("FinishActualTime")]
        public DateTime FinishActualTime { get; set; }
    }
}
