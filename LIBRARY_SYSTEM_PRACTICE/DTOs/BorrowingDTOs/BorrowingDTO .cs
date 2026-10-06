using LIBRARY_SYSTEM_PRACTICE.DTOs.BookDTOs;
using LIBRARY_SYSTEM_PRACTICE.DTOs.MemberDTOs;
using LIBRARY_SYSTEM_PRACTICE.Models;

namespace LIBRARY_SYSTEM_PRACTICE.DTOs.BorrowingDTOs
{
    public class BorrowingDTO
    {

        public int BorrowingId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public BookDTO Book { get; set; }
        public MemberDTO Member { get; set; }
    }
}
