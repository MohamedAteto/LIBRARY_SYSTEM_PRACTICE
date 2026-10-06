using AutoMapper;
using LIBRARY_SYSTEM_PRACTICE.DTOs.BookDTOs;
using LIBRARY_SYSTEM_PRACTICE.DTOs.BorrowingDTOs;
using LIBRARY_SYSTEM_PRACTICE.DTOs.MemberDTOs;
using LIBRARY_SYSTEM_PRACTICE.Mapping;
using LIBRARY_SYSTEM_PRACTICE.Models;
using LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LIBRARY_SYSTEM_PRACTICE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public BorrowingController(IUnitOfWork unit)
        {
            _unit = unit;
            _mapper = new MapperConfiguration(config => config.AddProfile<MappingProfiles>()).CreateMapper();
        }


        [HttpPost]
        public IActionResult Create(CreateBorrowingDTO DTO)
        {
            if (DTO is null)
                return BadRequest();

            var Entity = _mapper.Map<Borrowing>(DTO);

            _unit.BorrowingsRepo.Create(Entity);
            _unit.Save();

            return Ok();
        }

        [HttpGet]
        public IActionResult GetBorrowings()
        {
            var items = _unit.BorrowingsRepo.Get_all_borrowings_with_Member_and_Book_information_Order_the_newest_borrowings_first();

            if (items is null)
                return BadRequest("There isn't Data here !!");


            return Ok(items);

        }
    }
}
