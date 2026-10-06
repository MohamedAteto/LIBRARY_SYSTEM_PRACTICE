using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LIBRARY_SYSTEM_PRACTICE.Models;

namespace LIBRARY_SYSTEM_PRACTICE.DTOs.BorrowingDTOs
{
    public class CreateBorrowingDTO
    {
        [Required]
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
    }
}
