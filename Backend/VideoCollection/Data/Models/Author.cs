using System;

namespace VideoCollection.Data.Models
{
    public class Author: ILoggable
    {        
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int? AuthorAvatarId { get; set; }
        public AuthorAvatar AuthorAvatar { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
