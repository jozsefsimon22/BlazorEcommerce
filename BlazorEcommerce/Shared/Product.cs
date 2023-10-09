using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorEcommerce.Shared
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public Category? Category { get; set; }

        public int CategoryId { get; set; }

        public List<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
    }
}
