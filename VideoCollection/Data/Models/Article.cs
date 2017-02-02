using System.Collections.Generic;

namespace VideoCollection.Data.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
