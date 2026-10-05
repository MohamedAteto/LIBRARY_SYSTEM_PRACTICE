using LIBRARY_SYSTEM_PRACTICE.Models;

namespace LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface
{
    public interface IUnitOfWork 
    {
         IBookRepo BookRepo { get; }

        //ICategoryRepository Categories { get; }
        //IBorrowingRepository Borrowings { get; }
        void Save();
    }
}
