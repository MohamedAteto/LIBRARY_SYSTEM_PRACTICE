using AutoMapper;
using LIBRARY_SYSTEM_PRACTICE.DTOs.CategoryDTOs;
using LIBRARY_SYSTEM_PRACTICE.Mapping;
using LIBRARY_SYSTEM_PRACTICE.Models;
using LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LIBRARY_SYSTEM_PRACTICE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unit)
        {
            _unit = unit;
            _mapper = new MapperConfiguration(s => s.AddProfile<MappingProfiles>()).CreateMapper();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDTO DTO)
        {
            if (DTO is null)
                return BadRequest("Isn't good");



            var Entity = _mapper.Map<Category>(DTO);

            _unit.categoryRepo.Create(Entity);
            _unit.Save();

            return Ok("Added !!");


        }

        [HttpGet]
        public IActionResult GetWithDetials()
        {
            var items = _unit.categoryRepo.Get_all_categories_For_each_category_return_its_name_and_the_number_of_books_it_contains();

            if (items is null)
                return BadRequest();

            var DTO = _mapper.Map<CategoryDTO>(items);

            return Ok(DTO);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = _unit.categoryRepo.GetyId(id);

            if (item is null)
                return BadRequest();

            _unit.categoryRepo.Delete(id);
            _unit.Save();

            return Ok("Deleted !!");
        }
    }
}
