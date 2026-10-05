using LIBRARY_SYSTEM_PRACTICE.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using static System.Reflection.Metadata.BlobBuilder;

namespace LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface
{
    public interface IBookRepo : IGenericRepo<Book>
    {
        public ICollection<Book> Getsearch_keyword_from_the_user_Search_for_books_whose_Title_or_Author();
        public ICollection<Book> Get_the_book_with_the_highest_Price();



    }
}
