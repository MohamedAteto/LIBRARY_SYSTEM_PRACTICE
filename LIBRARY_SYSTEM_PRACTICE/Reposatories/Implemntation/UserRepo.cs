using LIBRARY_SYSTEM_PRACTICE.Data;
using LIBRARY_SYSTEM_PRACTICE.Models;
using LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface;

namespace LIBRARY_SYSTEM_PRACTICE.Reposatories.Implemntation
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        private readonly AppDbContext _context;
        public UserRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }

        
        public User GetUserByUserName(string userName)
        {
            var item = _context.users.FirstOrDefault(u => u.UserName == userName);

            if (item == null)
                throw new Exception("Not found");

            return item;
        }
    }
}
