using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities
{
    public class Product : BaseEntity
    {
        public int OfferId { get; set; }
        [StringLength(200)]
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockAmount { get; set; }
    }
}
