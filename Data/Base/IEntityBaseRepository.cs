using System.Linq.Expressions;

namespace eTickets.Data.Services
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();

        //GetAll with generic method that includes object parameters
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int Id);
        Task AddAsync(T entity);
        //Task<T> UpdateAsync(int Id, T entity);
        Task UpdateAsync(int Id, T entity);

        Task DeleteAsync(int Id);
    }
}
