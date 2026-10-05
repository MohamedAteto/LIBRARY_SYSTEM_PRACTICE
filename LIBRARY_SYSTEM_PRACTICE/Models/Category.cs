using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LIBRARY_SYSTEM_PRACTICE.Models
{
    [Index(nameof(CategoryName), IsUnique = true)]
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [MaxLength(200)]
        public string CategoryDescription { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
