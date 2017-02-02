using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoCollection.Data.Models
{
    public class ArticleTag
    {
        public int Id { get; set; }
        [ForeignKey("Article")]
        public int? ArticleId { get; set; }
        [ForeignKey("Tag")]
        public int? TagId { get; set; }
        public Article Article { get; set; }
        public Tag Tag { get; set; }
        public bool IsDeleted { get; set; }
    }
}
