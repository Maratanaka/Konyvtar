using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Konyvtar.Model
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;


        [Required]
        [MaxLength(100)]
        public string Author { get; set; } = string.Empty;


        [Required]
        [StringLength(13, MinimumLength = 13)]
        public string ISBN { get; set; } = string.Empty;


        [Range(1000, 2100)]
        public int PublishedYear { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be non-negative.")]
        public decimal Price { get; set; }


        public bool InStock { get; set; } = true;


        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
