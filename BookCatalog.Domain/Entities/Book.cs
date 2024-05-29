using BookCatalog.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace BookCatalog.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please provide title")]
        [StringLength(255)]
        public string? Title {  get; set; }
        [Required(ErrorMessage ="Please provide the author's name")]
        [StringLength(255)]
        public string? Author { get; set; }
        public DateTime? PublicationDate { get; set; }
        [EnumDataType(typeof(Category),ErrorMessage ="Please select a category")]
        public Category Category { get; set; }
    }
}
