using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Cache
{
    public class RepositoryMemCached
    {



        public static MemcachedClient Configure()
        {
            MemcachedClientConfiguration config = new MemcachedClientConfiguration();
            config.Servers.Add(new IPEndPoint(IPAddress.Loopback, 11211));
            config.Protocol = MemcachedProtocol.Binary;
            config.Authentication.Type = typeof(PlainTextAuthenticator);
            config.Authentication.Parameters["userName"] = "demo";
            config.Authentication.Parameters["password"] = "demo";

            var mc = new MemcachedClient(config);

            return mc;
               
        }

        public static bool StoreData(string key, string value)
        {
            return Configure().Store(StoreMode.Set, key, value);
        }
            
        public static string GetData(string key)
        {
            return Configure().Get(key).ToString();
        }

        public static void DeleteData(string key)
        {
            Configure().Remove(key);
        }

        ////public bool Add<T>(string key, T value, DateTimeOffset expiresAt) where T : class
        ////{
        ////    var serializedObject = JsonConvert.SerializeObject(value);
        ////    var expiration = expiresAt.Subtract(DateTimeOffset.Now);

        ////    return database.StringSet(key, serializedObject, expiration);
        ////}

        public T Get<T>(string key) where T : class
        {
            var serializedObject = Configure().Get<string>(key);

            return JsonConvert.DeserializeObject<T>(serializedObject);
        }
    }
}
