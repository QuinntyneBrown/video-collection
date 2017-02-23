using System.ComponentModel.DataAnnotations.Schema;

namespace VideoCollection.Data.Models
{
    public class AuthorAvatar
    {
        public int Id { get; set; }        
        public int? AuthorId { get; set; }
        public Author Author { get; set; }        
        public string Url { get; set; }
        public bool IsDeleted { get; set; }
    }
}
