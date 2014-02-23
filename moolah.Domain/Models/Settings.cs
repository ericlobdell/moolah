using System;

namespace moolah.Domain.Models
{
    public class Settings
    {
        public DateTime BasePayDay { get; set; }
        public int PayWeekInterval { get; set; }
        public decimal PaycheckAmount { get; set; }
    }
}
