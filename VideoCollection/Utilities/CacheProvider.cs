using VideoCollection.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoCollection.Utilities
{
    public class CacheProvider : ICacheProvider
    {
        public ICache GetCache()
        {
            return MemoryCache.Current;
        }
    }
}
