using AquaZooWeb.Models;

namespace AquaZooWeb.UIRepository
{
    public interface IAccountRepository:IUIRepository<User> 
    {
        Task<User> LoginAsync(string url, User newUser);

        Task<bool> RegisterAsync(string url, User validUser);
    }
}
