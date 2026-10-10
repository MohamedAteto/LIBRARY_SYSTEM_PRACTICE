using AutoMapper.Execution;
using LIBRARY_SYSTEM_PRACTICE.DTOs.MemberDTOs;
using LIBRARY_SYSTEM_PRACTICE.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface
{
    public interface IMemberRepo : IGenericRepo<Models.Member>
    {
        public ICollection<MemberDTO> Get_the_top_5_members_based_on_the_number_of_books_they_borrowed();
        public ICollection<MemberDTO> Order_members_by_borrowing_count_descending_using_LINQ();


    }
}
