using System;

namespace VideoCollection.Utilities
{
    public class RedisCache : Cache
    {
        public override void Add(object objectToCache, string key)
        {
            throw new NotImplementedException();
        }

        public override void Add<T>(object objectToCache, string key)
        {
            throw new NotImplementedException();
        }

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

        public override object Get(string key)
        {
            throw new NotImplementedException();
        }

        public override T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public override void Remove(string key)
        {
            throw new NotImplementedException();
        }
    }
}
