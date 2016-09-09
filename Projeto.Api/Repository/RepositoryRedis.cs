using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Api.Repository
{
    public class RepositoryRedis
    {
        private static ConnectionMultiplexer connectionMultiplexer;
        private static IDatabase database;

        public RepositoryRedis()
        {
            Configure();
        }

        private static void Configure()
        {
            //use locally redis installation
            var connectionString = string.Format("{0}:{1}", "localhost", 6379);

            connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
            database = connectionMultiplexer.GetDatabase();
        }

        public async static Task<bool> StoreDataAsync(string key, string value)
        {
            Configure();
            return await database.StringSetAsync(key, value);
        }

        public async static Task<string> GetDataAsync(string key)
        {
            Configure();
            return await database.StringGetAsync(key);
        }

        public async static void DeleteDataAsync(string key)
        {
            Configure();
            await database.KeyDeleteAsync(key);
        }

        public async Task<bool> AddAsync<T>(string key, T value, DateTimeOffset expiresAt) where T : class
        {
            List<T> lista = new List<T>();
            lista.Add(value);

            if (database.KeyExists(key))
            {
                lista.AddRange(await GetListAsync<T>(key));
            }

            var serializedObject = JsonConvert.SerializeObject(lista);
            var expiration = expiresAt.Subtract(DateTimeOffset.Now);

            return await database.StringSetAsync(key, serializedObject, expiration);
        }

        public async Task<T> Get<T>(string key) where T : class
        {
            var serializedObject = await database.StringGetAsync(key);

            return JsonConvert.DeserializeObject<T>(serializedObject);
        }

        public async Task<List<T>> GetListAsync<T>(string key) where T : class
        {
            var serializedObject = await database.StringGetAsync(key);
            return JsonConvert.DeserializeObject<List<T>>(serializedObject);
        }

        public async Task<List<T>> GetListPaginadaAsync<T>(string key, int page, int size) where T : class
        {
            var serializedObject = await database.StringGetAsync(key);
            var result = await JsonConvert.DeserializeObjectAsync<List<T>>(serializedObject);

            var _paginado = result.Skip((page - 1) * size).Take(size);

            return _paginado.ToList();

        }

        public void Push<T>(string key, T value, DateTimeOffset expiresAt) where T : class
        { 
            var serializedObject = JsonConvert.SerializeObject(value);
            var expiration = expiresAt.Subtract(DateTimeOffset.Now);

            database.StringAppend(key, serializedObject);
        }

        public async Task<bool> Exists(string key)
        {
            if (await database.KeyExistsAsync(key))
            {
                return true;
            }

            return false;
        }
    }
}