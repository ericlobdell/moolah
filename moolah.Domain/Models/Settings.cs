using System;

namespace moolah.Domain.Models
{
    public class Settings
    {
        public int Id { get; set; }
        public DateTime BasePayDay { get; set; }
        public int PayInterval { get; set; }
        public PaymentInterval IntervalType { get; set; }
        public decimal PaycheckAmount { get; set; }
    }

    public enum PaymentInterval
    {
        Days = 0,
        Weeks = 1, 
        Months = 2
    }
}
