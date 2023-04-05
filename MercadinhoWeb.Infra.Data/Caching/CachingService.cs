using MercadinhoWeb.Domain.Interfaces.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadinhoWeb.Infra.Data.Caching;

public class CachingService : ICachingService
{
    private readonly IDistributedCache _cache;
    private readonly DistributedCacheEntryOptions _options;
    private readonly ILogger<CachingService> _logger;

    public CachingService(IDistributedCache cache, ILogger<CachingService> logger, DistributedCacheEntryOptions options)
    {
        _cache = cache;
        _options = options;
        _logger = logger;
    }

    public async Task<string> GetAsync(string key)
    {
        try
        {
            return await _cache.GetStringAsync(key);

        }catch(RedisException ex)
        {
            _logger.LogError($"Erro ao acessar o redis para verificar informação com a chave ({key}).", ex);
            return null;
        }
        
    }

    public async Task SetAsync(string key, string value)
    {
        try
        {
            await _cache.SetStringAsync(key, value, _options);
        }
        catch (RedisException ex)
        {
            _logger.LogError($"Erro ao acessar o redis para registrar informação com a chave ({key}).", ex);
        }
    }
}
