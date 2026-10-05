using LIBRARY_SYSTEM_PRACTICE.Models;

namespace LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface
{
    public interface IUnitOfWork 
    {
         IBookRepo BookRepo { get; }

        ICategoryRepo categoryRepo { get; }

        public IMemberRepo memberRepo { get; }

        //IBorrowingRepository Borrowings { get; }
        void Save();
    }
}
