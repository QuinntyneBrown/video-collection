using System;

namespace VideoCollection.Data.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
