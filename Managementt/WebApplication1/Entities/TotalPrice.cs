namespace WebApplication1.Entities
{
    public class TotalPrice : BaseEntity
    {
        public int OfferId { get; set; }
        public decimal Total { get; set; }
        public decimal VAT { get; set; }
    }
}
