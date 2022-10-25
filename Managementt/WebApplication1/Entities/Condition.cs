using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities
{
    public class Condition : BaseEntity
    {
        public int OfferId { get; set; }
        [StringLength(500)]
        public string Requirement { get; set; }
    }
}
