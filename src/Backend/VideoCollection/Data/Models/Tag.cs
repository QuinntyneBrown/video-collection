using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoCollection.Data.Models
{
    public class Tag
    {
        public int Id { get; set; }
        [ForeignKey("Tenant")]
        public int? TenantId { get; set; }
        public string Name { get; set; }
        public Tenant Tenant { get; set; }
        public ICollection<ArticleTag> Articles { get; set; } = new HashSet<ArticleTag>();
        public bool IsDeleted { get; set; }
    }
}
