using LIBRARY_SYSTEM_PRACTICE.Data;
using LIBRARY_SYSTEM_PRACTICE.Models;
using LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface;

namespace LIBRARY_SYSTEM_PRACTICE.Reposatories.Implemntation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context; 
        public IBookRepo BookRepo { get; }

        public UnitOfWork(AppDbContext context,IBookRepo bookRepo)
        {
            BookRepo = bookRepo;
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();   
        }
    }
}
