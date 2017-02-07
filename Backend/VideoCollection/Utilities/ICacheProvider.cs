using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoCollection.Utilities
{
    public interface ICacheProvider
    {
        ICache GetCache();
    }
}
