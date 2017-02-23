using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoCollection.Data.Models
{
    public class VideoArticle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Video")]
        public int? VideoId { get; set; }
        [ForeignKey("Article")]
        public int? ArticleId { get; set; }
        public Video Video { get; set; }
        public Article Article { get; set; }
        public bool IsDeleted { get; set; }
    }
}
