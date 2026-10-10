using LIBRARY_SYSTEM_PRACTICE.Data;
using LIBRARY_SYSTEM_PRACTICE.Models;
using LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface;

namespace LIBRARY_SYSTEM_PRACTICE.Reposatories.Implemntation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context; 
        public IBookRepo BookRepo { get; }
        public ICategoryRepo categoryRepo { get; }
        public IMemberRepo memberRepo { get; }
        public IBorrowRepo BorrowingsRepo { get; }
        public IUserRepo userRepo { get; }

        public UnitOfWork(AppDbContext context,
            IBookRepo bookRepo ,
            ICategoryRepo categoryRepoo,
            IBorrowRepo borrowRepo,IMemberRepo memberRepo, IUserRepo userRepo)
        {
            BookRepo = bookRepo;
            _context = context;
            categoryRepo = categoryRepoo;
            BorrowingsRepo = borrowRepo;
            this.memberRepo = memberRepo;
            this.userRepo = userRepo;
        }


        public void Save()
        {
            _context.SaveChanges();   
        }
    }
}
