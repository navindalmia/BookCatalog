using BookCatalog.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string? Title {  get; set; }
        [Required]
        [StringLength(255)]
        public string? Author { get; set; }
        public DateTime? PublicationDate { get; set; }
        public Category Category { get; set; }
    }
}
