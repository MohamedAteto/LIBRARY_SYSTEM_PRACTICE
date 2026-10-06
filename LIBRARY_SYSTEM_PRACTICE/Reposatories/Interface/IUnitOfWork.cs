using LIBRARY_SYSTEM_PRACTICE.Models;

namespace LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface
{
    public interface IUnitOfWork 
    {
         IBookRepo BookRepo { get; }

        ICategoryRepo categoryRepo { get; }

        IMemberRepo memberRepo { get; }

        IBorrowRepo BorrowingsRepo { get; }
        void Save();
    }
}
