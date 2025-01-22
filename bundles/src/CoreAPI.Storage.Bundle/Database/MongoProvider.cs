using MongoDB.Driver;

namespace CoreAPI.Storage.Bundle.Database;

public sealed class MongoProvider : IDatabaseProvider
{
    private readonly IMongoDatabase _mongoDatabase;
    
    private IMongoCollection<T> GetCollection<T>() => _mongoDatabase.GetCollection<T>(nameof(T));

    public MongoProvider(string connectionString, string databaseName)
    {
        MongoClient mongoClient = new(connectionString);
        _mongoDatabase = mongoClient.GetDatabase(databaseName);
    }

    public async Task<T> CreateAsync<T>(T entity, CancellationToken ctx) where T : class
    {
        InsertOneOptions options = new();
        await GetCollection<T>().InsertOneAsync(entity, options, ctx);
        
        return entity;
    }

    public async Task<T> GetOneAsync<T>(Guid id, CancellationToken ctx) where T : class
    {
        var filter = Builders<T>.Filter.Eq("id", id);
        return await GetCollection<T>().Find(filter).FirstOrDefaultAsync(ctx);
    }

    public async Task<T> ReplaceAsync<T>(Guid id, T entity, CancellationToken ctx) where T : class
    {
        var filter = Builders<T>.Filter.Eq("id", id);
        ReplaceOptions replaceOptions = new();
        
        await GetCollection<T>().ReplaceOneAsync(filter, entity, replaceOptions, ctx);
        return entity;
    }

    public async Task DeleteAsync<T>(Guid id, CancellationToken ctx) where T : class
    {
        var filter = Builders<T>.Filter.Eq("id", id);
        await GetCollection<T>().DeleteOneAsync(filter, ctx);
    }
}