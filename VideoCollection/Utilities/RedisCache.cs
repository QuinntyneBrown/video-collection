using System;
using Microsoft.Practices.Unity;
using StackExchange.Redis;
using Newtonsoft.Json;
using VideoCollection.Data.Models;
using System.Collections.Generic;

namespace VideoCollection.Utilities
{
    public class RedisCache : Cache
    {
        RedisCache()
        {
            var connection = ConnectionMultiplexer.Connect(_redisCacheConfiguration.ConnectionString);
            _database = connection.GetDatabase();
        }

        private static volatile VideoCollection.Utilities.RedisCache _current = null;

        
        private IDatabase _database { get; set; }

        [Dependency]
        public IRedisCacheConfiguration _redisCacheConfiguration { get { return RedisCacheConfiguration.Config; } }

        public static RedisCache Current
        {
            get
            {
                if (_current == null)
                    _current = new RedisCache();
                return _current;
            }
        }

        public override void Add(object objectToCache, string key)
        {
            _database.StringSet(key, JsonConvert.SerializeObject(objectToCache));
        }

        public override void Add<T>(object objectToCache, string key) => Add(objectToCache, key);


        public override void Add<T>(object objectToCache, string key, double cacheDuration)
        {
            throw new NotImplementedException();
        }

        public override void ClearAll()
        {
            throw new NotImplementedException();
        }

        public override bool Exists(string key)
        {
            throw new NotImplementedException();
        }

        public override T Get<T>(string key)
        {
            RedisValue redisValue = _database.StringGet(key);

            if (redisValue.IsNull)
                return default(T);

            return JsonConvert.DeserializeObject<T>(redisValue);
        }

        public override object Get(string key)
        {
            RedisValue redisValue = _database.StringGet(key);

            if (redisValue.IsNull)
                return null;

            return JsonConvert.DeserializeObject<List<DigitalAsset>>(redisValue);
        }

        public override void Remove(string key)
        {
            throw new NotImplementedException();
        }
    }
}
