using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities
{
    public class Customer : BaseEntity
    {
        public int OfferId { get; set; }
        [StringLength(500)]
        public string CompanyName { get; set; }
    }
}
