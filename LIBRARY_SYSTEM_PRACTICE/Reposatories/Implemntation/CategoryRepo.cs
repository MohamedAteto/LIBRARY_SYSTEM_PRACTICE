using LIBRARY_SYSTEM_PRACTICE.Data;
using LIBRARY_SYSTEM_PRACTICE.DTOs.CategoryDTOs;
using LIBRARY_SYSTEM_PRACTICE.Models;
using LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

namespace LIBRARY_SYSTEM_PRACTICE.Reposatories.Implemntation
{
    public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
    {
        private readonly AppDbContext _context;

        public CategoryRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public ICollection<Category> Get_all_categories_For_each_category_return_its_name_and_the_number_of_books_it_contains()
        {
            var items = _context.Categories
            .Include(c => c.Books)
            .ToList();


            if (items is null)
                throw new Exception();

            return items;
        }


    }
}
