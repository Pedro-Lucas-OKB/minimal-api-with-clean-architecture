﻿using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);

    Task<T?> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<List<T>?> GetAllAsync(CancellationToken cancellationToken);
}
