using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Entities
{
    public class Explanation : BaseEntity
    {
        public int OfferId { get; set; }
        [StringLength(500)]
        public string Title { get; set; }
        [StringLength(2000)]
        public string Comment { get; set; }
    }
}
