using LIBRARY_SYSTEM_PRACTICE.Models;

namespace LIBRARY_SYSTEM_PRACTICE.Reposatories.Interface
{
    public interface IUserRepo : IGenericRepo<User>
    { 
        public User GetUserByUserName (string userName);

    }
}
