using Newtonsoft.Json;
using StackExchange.Redis;
using System;

namespace Projeto.Cache
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

            //use azure redis installation
            var azureConnectionString = string.Format("{0}:{1},ssl=true,password={2}",
                                    "conttaredis.redis.cache.windows.net",
                                    6380,
                                    "4SegD1KMNxeozIeT+5tqDld1LMIh2kLLMo+caQmjvbA=");

            connectionMultiplexer = ConnectionMultiplexer.Connect(connectionString);
            database = connectionMultiplexer.GetDatabase();
        }

        public static bool StoreData(string key, string value)
        {
            return database.StringSet(key, value);
        }

        public static string GetData(string key)
        {
            return database.StringGet(key);
        }

        public static void DeleteData(string key)
        {
            database.KeyDelete(key);
        }

        public bool Add<T>(string key, T value, DateTimeOffset expiresAt) where T : class
        {
            var serializedObject = JsonConvert.SerializeObject(value);
            var expiration = expiresAt.Subtract(DateTimeOffset.Now);

            return database.StringSet(key, serializedObject, expiration);
        }

        public T Get<T>(string key) where T : class
        {
            var serializedObject = database.StringGet(key);

            return JsonConvert.DeserializeObject<T>(serializedObject);
        }
    }
}