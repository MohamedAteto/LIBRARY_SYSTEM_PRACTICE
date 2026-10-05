using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LIBRARY_SYSTEM_PRACTICE.Models
{
    public class Borrowing
    {
        [Key]
        public int BorrowingId { get; set; }
        [Required]
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }



        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }

        public int MemberId { get; set; }
        [ForeignKey("MemberId")]
        public Member Member { get; set; }
    }
}
