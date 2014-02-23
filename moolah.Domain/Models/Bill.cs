namespace moolah.Domain.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPaid { get; set; }
        public decimal Amount { get; set; }
        public bool IsAutoPay { get; set; }
        public bool IsChargedInetrest { get; set; }
        public decimal? InterestRate { get; set; }
        public int DueDayOfMonth { get; set; }
        public int PayeeId { get; set; }
    }
}
