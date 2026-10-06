using LIBRARY_SYSTEM_PRACTICE.DTOs.BorrowingDTOs;
using LIBRARY_SYSTEM_PRACTICE.Models;

namespace LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface
{
    public interface IBorrowRepo : IGenericRepo<Borrowing> 
    {
        public IEnumerable<BorrowingDTO> Get_all_borrowings_with_Member_and_Book_information_Order_the_newest_borrowings_first();
    }
}
