using System;

namespace VideoCollection.Data.Models
{
    public class Video
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string YouTubeVideoId { get; set; }
        public string Abstract { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
