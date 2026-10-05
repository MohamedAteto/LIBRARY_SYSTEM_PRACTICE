using LIBRARY_SYSTEM_PRACTICE.Data;
using LIBRARY_SYSTEM_PRACTICE.DTOs.CategoryDTOs;
using LIBRARY_SYSTEM_PRACTICE.Models;
using LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface;

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
            //   return _context.Categories
            //.Select(c => new CategoryDTO
            //{
            //    Id = c.CategoryId,
            //    Name = c.CategoryName,
            //    BookCount = c.Books.Count
            //})
            //.ToList();

            var categories = _context.Categories
                .Select(c => new Category
                {
                    CategoryId = c.CategoryId,
                    CategoryName = c.CategoryName,
                    Books = c.Books
                })
                .ToList();
            foreach (var category in categories)
            {
                category.Books = category.Books ?? new List<Book>();
            }
            return categories;
        }
    }
}
