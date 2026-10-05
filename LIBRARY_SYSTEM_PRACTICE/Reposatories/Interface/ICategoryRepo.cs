using LIBRARY_SYSTEM_PRACTICE.Models;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface
{
    public interface ICategoryRepo : IGenericRepo<Category>
    {
        public ICollection<Category> Get_all_categories_For_each_category_return_its_name_and_the_number_of_books_it_contains();
    }
}
