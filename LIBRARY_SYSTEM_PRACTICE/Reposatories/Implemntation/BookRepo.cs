using LIBRARY_SYSTEM_PRACTICE.Data;
using LIBRARY_SYSTEM_PRACTICE.Models;
using LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface;

namespace LIBRARY_SYSTEM_PRACTICE.Reposatories.Implemntation
{
    public class BookRepo :  GenericRepo<Book> , IBookRepo
    {
        private readonly AppDbContext _context;
        public BookRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public ICollection<Book> Getsearch_keyword_from_the_user_Search_for_books_whose_Title_or_Author(string keyword)
        {
            var books = _context.Books
                .Where(b => b.Title.Contains(keyword) || b.Author.Contains(keyword))
                .OrderBy(b => b.Title)
                .ToList();

            if (books.Count == 0)
                Console.WriteLine("No books found matching the keyword.");
            
            //else
            //{
            //    Console.WriteLine($"Found {books.Count} book(s):");
            //    foreach (var book in books)
            //    {
            //        Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}, Price: {book.BookPrice}, Available: {book.IsAvailable}");
            //    }
            //}

            return books;
        }

        public ICollection<Book> Get_the_book_with_the_highest_Price()
        {
            var items = _context.Books.
                OrderByDescending(s => s.BookPrice)
                .ToList();

            if (items == null || items.Count == 0)
                throw new ArgumentNullException(nameof(items));

            return items;
        }
    }
}
