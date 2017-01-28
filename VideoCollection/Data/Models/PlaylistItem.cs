using System;

namespace VideoCollection.Data.Models
{
    public class PlaylistItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Priority { get; set; } = 0;
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } 
        public bool IsDeleted { get; set; }
    }
}
