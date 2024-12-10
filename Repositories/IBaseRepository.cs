
namespace OpenAiVideoSummary.Api.Repository
{
    public interface IBaseRepository<T>
    {
        Task CreateAsync(T entity);
        Task DeleteAsync(string id);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(string id);
        Task UpdateAsync(string id, T entity);
    }
}