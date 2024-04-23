using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SalaryAccountingLib
{
    public class WorkingDay
    {
        [JsonPropertyName("Date")]
        public DateTime Date { get; set; }
        private int hours;
        [JsonPropertyName("Value")]
        public string Hours
        {
            get => hours.ToString();
            set => hours = (value != "б") ? Convert.ToInt32(value) : -1;
        }
        [JsonPropertyName("Status")]
        public StatusDay Status { get; set; }
    }

}
