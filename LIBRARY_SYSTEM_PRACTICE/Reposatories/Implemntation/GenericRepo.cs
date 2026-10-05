using LIBRARY_SYSTEM_PRACTICE.Data;
using LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface;
using Microsoft.EntityFrameworkCore;

namespace LIBRARY_SYSTEM_PRACTICE.Reposatories.Implemntation
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> db;
        public GenericRepo(AppDbContext context) { 
        
            _context = context;
            db = _context.Set<T>();

        }
        public void Create(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            db.Add(entity);

        }

        public void Delete(int id)
        {
            var item = db.Find(id);
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            db.Remove(item);

        }

        public ICollection<T> GetAll()
        {
            var items = db.ToList();

            if (items == null || items.Count == 0)
                throw new ArgumentNullException(nameof(items));

            return items;
        }

        public T GetyId(int id)
        {
            var item = db.Find(id);

            if (item == null)
                throw new ArgumentNullException(nameof(item));

            return item;
        }

        public void Update(int id, T entity)
        {
            var item = db.Find(id);

            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _context.Entry(item).CurrentValues.SetValues(entity);
        }
    }
}
