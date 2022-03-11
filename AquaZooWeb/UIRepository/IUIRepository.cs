namespace AquaZooWeb.UIRepository
{
    interface  IUIRepository<T> where T: class 
    {
        Task<T> GetAsync(string url, int Id);
        Task<IEnumerable<T>> GetAllAsync(string url);

        Task<bool> CreateAsync(string url, T createObj);

        Task<bool> UpdateAsync(string url, T createObj);

        Task<bool> DeleteAsync(string url, int Id);
    }
}
