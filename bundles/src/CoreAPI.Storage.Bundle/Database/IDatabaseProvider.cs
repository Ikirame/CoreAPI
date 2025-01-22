namespace CoreAPI.Storage.Bundle.Database;

public interface IDatabaseProvider
{
    Task<T> CreateAsync<T>(T entity, CancellationToken ctx) where T : class;
    Task<T> GetOneAsync<T>(Guid id, CancellationToken ctx) where T : class;
    Task<T> ReplaceAsync<T>(Guid id, T entity, CancellationToken ctx) where T : class;
    Task DeleteAsync<T>(Guid id, CancellationToken ctx) where T : class;
}