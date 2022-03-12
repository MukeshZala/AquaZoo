using AquaZooAPI.Models;

namespace AquaZooAPI.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string username);
        User Authenticate(string username, string password);

        User Register(string username, string password); 


    }
}
