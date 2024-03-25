namespace I_Invoice_Repository_Pattern.Models
{
    public class Invoice : Base
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
