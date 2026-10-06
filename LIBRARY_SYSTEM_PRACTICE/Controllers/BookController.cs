using AutoMapper;
using LIBRARY_SYSTEM_PRACTICE.Data;
using LIBRARY_SYSTEM_PRACTICE.DTOs.BookDTOs;
using LIBRARY_SYSTEM_PRACTICE.Mapping;
using LIBRARY_SYSTEM_PRACTICE.Models;
using LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LIBRARY_SYSTEM_PRACTICE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public BookController(IUnitOfWork unit)
        {
            _unit = unit;
            _mapper = new MapperConfiguration(s => s.AddProfile<MappingProfiles>()).CreateMapper(); 
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateBookDTO DTO)
        {
            if (DTO == null)
                return BadRequest("Book data is null.");

            var Entity = _mapper.Map<Book>(DTO);
            _unit.BookRepo.Create(Entity);
            _unit.Save();

            return Ok(DTO);

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var books = _unit.BookRepo.Getsearch_keyword_from_the_user_Search_for_books_whose_Title_or_Author();

            if(books == null || !books.Any())
                return NotFound("No books found.");
            
            var bookDTOs = _mapper.Map<List<BookDTO>>(books);

            return Ok(bookDTOs);
        }

        [HttpGet("Get_With_Highst_Price")]
        public IActionResult GetWithHighestPrice()
        {
            var book = _unit.BookRepo.Get_the_book_with_the_highest_Price();
            if (book == null)
                return NotFound("No books found.");

            var bookDTO = _mapper.Map<List<BookDTO>>(book);
            return Ok(bookDTO);
        }


    }
}
