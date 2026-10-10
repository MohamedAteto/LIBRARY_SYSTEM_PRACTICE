using System.Net.WebSockets;
using AutoMapper;
using LIBRARY_SYSTEM_PRACTICE.DTOs.MemberDTOs;
using LIBRARY_SYSTEM_PRACTICE.Mapping;
using LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LIBRARY_SYSTEM_PRACTICE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public MemberController(IUnitOfWork unit)
        {
            _unit = unit;
            _mapper = new MapperConfiguration(s => s.AddProfile<MappingProfiles>()).CreateMapper();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var items = _unit.memberRepo.Get_the_top_5_members_based_on_the_number_of_books_they_borrowed();

            if (items is null)
                return BadRequest();


            return Ok(items);

        }


        [HttpGet("By ORder")]
        public IActionResult GetAllWithorder()
        {
            var items = _unit.memberRepo.Order_members_by_borrowing_count_descending_using_LINQ();

            if (items is null)
                return BadRequest();


            return Ok(items);

        }


    }

}
