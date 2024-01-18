using Microsoft.Extensions.Caching.Memory;
namespace BusinessLayer;
public class CacheService : ICache
{
    private readonly int _cacheTime;
    private readonly IMemoryCache _memoryCache;

    public CacheService(IMemoryCache memoryCache, int cacheTime = 60)
    {
        _memoryCache = memoryCache;
        _cacheTime = cacheTime;
    }

    /// Gets the value associated with the specified key.
    public T? Get<T>(string key)
    {
        return _memoryCache.Get<T>(key);

    }

    /// Adds the specified key and object to the cache.
    public void Set(string key, object objectData, int? cacheTime = null)
    {
        if (objectData == null)
        {
            return;
        }

        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetAbsoluteExpiration(TimeSpan.FromMinutes(cacheTime ?? _cacheTime));

        _memoryCache.Set(key, objectData, cacheEntryOptions);
    }

    /// Gets a value indicating whether the value associated
    /// with the specified key is cached
    public bool IsSet(string key)
    {
        return _memoryCache.TryGetValue(key, out _);
    }

    /// Removes the value with the specified key from the cache
    public void Remove(string key)
    {
        _memoryCache.Remove(key);
    }

    public void RemoveByPattern(string pattern)
    {
        // Not implemented for in-memory cache
    }

    /// Clear all cache data
    public void Clear()
    {
        _memoryCache.Dispose();
    }
}