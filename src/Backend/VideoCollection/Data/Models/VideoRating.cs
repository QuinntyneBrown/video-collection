using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoCollection.Data.Models
{
    public class VideoRating: ILoggable
    {
        public int Id { get; set; }
        [ForeignKey("Video")]
        public int? VideoId { get; set; }
        public decimal Rating { get; set; }
        public Video Video { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
