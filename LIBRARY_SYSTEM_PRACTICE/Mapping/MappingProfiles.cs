using AutoMapper;
using LIBRARY_SYSTEM_PRACTICE.DTOs.BookDTOs;
using LIBRARY_SYSTEM_PRACTICE.DTOs.CategoryDTOs;
using LIBRARY_SYSTEM_PRACTICE.DTOs.MemberDTOs;
using LIBRARY_SYSTEM_PRACTICE.Models;

namespace LIBRARY_SYSTEM_PRACTICE.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Book, CreateBookDTO>().ReverseMap();

            CreateMap<Category, CategoryDTO>()
                .ForMember(s => s.BookCount, m => m.MapFrom(n => n.Books.Count));

            CreateMap<Category, CreateCategoryDTO>().ReverseMap();



            CreateMap<Member, MemberDTO>()
                .ForMember(s => s.MemberBookcount, m => m.MapFrom(b => b.Borrowings.Count));

            CreateMap<Member, CreateMemberDTO>().ReverseMap();




       
        }
    }
}