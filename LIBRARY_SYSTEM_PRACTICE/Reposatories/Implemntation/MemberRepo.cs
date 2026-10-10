using LIBRARY_SYSTEM_PRACTICE.Data;
using LIBRARY_SYSTEM_PRACTICE.DTOs.MemberDTOs;
using LIBRARY_SYSTEM_PRACTICE.Models;
using LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Storage;

namespace LIBRARY_SYSTEM_PRACTICE.Reposatories.Implemntation
{
    public class MemberRepo : GenericRepo<Member>, IMemberRepo
    {
        private readonly AppDbContext _context;

        public MemberRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public ICollection<MemberDTO> Get_the_top_5_members_based_on_the_number_of_books_they_borrowed()
        {
            var items = _context.Members
                .OrderByDescending(s => s.Borrowings.Count)
                .Take(5)
                .Select(s => new MemberDTO
                {
                   MemberFullName = s.MemberFullName,
                   MemberEmail = s.MemberEmail,
                   MemberPhone = s.MemberPhone,
                   MemberBookcount = s.Borrowings.Count
                })
                .ToList();

            if (items is null)
                throw new Exception();

            return items;

        }

        public ICollection<MemberDTO> Order_members_by_borrowing_count_descending_using_LINQ()
        {
            var items = _context.Members
                .OrderByDescending(s => s.Borrowings.Count)
                  .Select(s => new MemberDTO
                  {
                      MemberFullName = s.MemberFullName,
                      MemberEmail = s.MemberEmail,
                      MemberPhone = s.MemberPhone,
                      MemberBookcount = s.Borrowings.Count
                  })
                .ToList();

            if (items is null)
                throw new Exception();

            return items;
        }
    }
}
