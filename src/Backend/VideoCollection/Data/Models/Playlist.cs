using System;
using System.Collections.Generic;

namespace VideoCollection.Data.Models
{
    public class Playlist: ILoggable
    {
        public int Id { get; set; }
        public ICollection<PlaylistItem> PlaylistItems { get; set; } = new HashSet<PlaylistItem>();
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
