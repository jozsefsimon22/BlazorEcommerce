﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorEcommerce.Shared
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public List<Image> Images { get; set; } = new List<Image>();

        public Category? Category { get; set; }

        public int CategoryId { get; set; }

        public bool Featured { get; set; }

        public List<ProductVariant> Variants { get; set; } = new List<ProductVariant>();

        public bool Visible { get; set; } = true;

        public bool Deleted { get; set; } = false;

        [NotMapped]
        public bool Editing { get; set; } = false;

        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}
