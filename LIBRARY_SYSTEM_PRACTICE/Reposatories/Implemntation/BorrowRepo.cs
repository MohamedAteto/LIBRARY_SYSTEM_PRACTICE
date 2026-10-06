using LIBRARY_SYSTEM_PRACTICE.Data;
using LIBRARY_SYSTEM_PRACTICE.DTOs.BookDTOs;
using LIBRARY_SYSTEM_PRACTICE.DTOs.BorrowingDTOs;
using LIBRARY_SYSTEM_PRACTICE.DTOs.MemberDTOs;
using LIBRARY_SYSTEM_PRACTICE.Models;
using LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace LIBRARY_SYSTEM_PRACTICE.Reposatories.Implemntation
{
    public class BorrowRepo : GenericRepo<Borrowing>, IBorrowRepo
    {
        private readonly AppDbContext _context;

        public BorrowRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public IEnumerable<BorrowingDTO> Get_all_borrowings_with_Member_and_Book_information_Order_the_newest_borrowings_first()
        {
            var items = _context.Borrowings
                .OrderByDescending(s => s.BorrowDate)
                .Select(m => new BorrowingDTO
                {
                    BorrowingId = m.BorrowingId,
                    BorrowDate = m.BorrowDate,
                    ReturnDate = m.ReturnDate,

                    Book = m.Book == null ? null : new BookDTO
                    {
                        BookId = m.BookId,
                        Title = m.Book.Title,
                        Author = m.Book.Author,
                        BookPrice = m.Book.BookPrice
                    },

                    Member = m.Member == null ? null : new MemberDTO
                    {
                        MemberFullName = m.Member.MemberFullName,
                        MemberEmail = m.Member.MemberEmail,
                        MemberPhone = m.Member.MemberPhone,
                        MemberBookcount = m.Member.Borrowings != null ? m.Member.Borrowings.Count :0,

                    }

                }).ToList();

            return items;
        }
    }
}
