using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoCollection.Data.Models
{
    public class Article: ILoggable, IPubllishable
    {
        public int Id { get; set; }
        public int? TenantId { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string Abstract { get; set; }
        public string Body { get; set; }
        [ForeignKey("Author")]
        public int? AuthorId { get; set; }
        public Author Author { get; set; }
        public DateTime? PublishedDate { get; set; }
        public ICollection<ArticleTag> Tags { get; set; } = new HashSet<ArticleTag>();
        public DateTime? PublishedOn { get; set; }
        public string PublishedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public Tenant Tenant { get; set; }
        public bool IsDeleted { get; set; }
    }
}
