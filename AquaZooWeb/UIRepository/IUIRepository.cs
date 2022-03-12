namespace AquaZooWeb.UIRepository
{
    public interface  IUIRepository<T> where T: class 
    {
        Task<T> GetAsync(string url, int Id, string token);
        Task<IEnumerable<T>> GetAllAsync(string url, string token);

        Task<bool> CreateAsync(string url, T createObj, string token);

        Task<bool> UpdateAsync(string url, T createObj, string token);

        Task<bool> DeleteAsync(string url, int Id, string token);
    }
}
