using System;

namespace VideoCollection.Data.Models
{
    public interface IPubllishable
    {
        DateTime PublishedOn { get; set; }
        string PublishedBy { get; set; }
    }
}
