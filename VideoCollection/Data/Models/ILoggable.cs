using System;

namespace VideoCollection.Data.Models
{
    public interface ILoggable
    {
        DateTime CreatedOn { get; set; }
        string CreatedBy { get; set; }
    }
}
