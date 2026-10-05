namespace LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface
{
    public interface IGenericRepo<T> where T : class
    {
        public ICollection<T> GetAll();
        public T GetyId(int id);
        public void Create(T entity);
        public void Update( int id ,T entity);
        public void Delete(int id);
    }
}
