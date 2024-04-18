using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);

    Task<T> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<List<T>> GetAllAsync(Guid id, CancellationToken cancellationToken);
}
