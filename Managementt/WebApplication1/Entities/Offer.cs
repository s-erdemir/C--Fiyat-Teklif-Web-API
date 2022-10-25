using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities
{
    public class Offer : BaseEntity
    {
        public int Id { get; set; }
        [StringLength(500)]
        public string OfferName { get; set; }

        public List<Condition> Conditions { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Explanation> Explanations { get; set; }
        public List<Prepared> Prepareds { get; set; }
        public List<Product> Products { get; set; }
        public List<TotalPrice> TotalPrices { get; set; }
    }
}
