using System.ComponentModel.DataAnnotations;

namespace LIBRARY_SYSTEM_PRACTICE.DTOs.BookDTOs
{
    public class CreateBookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public decimal BookPrice { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int CategoryId { get; set; }
    }
}
