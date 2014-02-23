using System;

namespace moolah.Domain.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Note { get; set; }
        public bool OnTime { get; set; }
    }
}
