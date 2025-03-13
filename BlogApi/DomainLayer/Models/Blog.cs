using DomainLayer.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApi.DomainLayer.Models
{
    public class Blog : BaseModel
    {
        public string Post { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public int AuthorId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("CommentId")]
        public Comment Comment { get; set; }
        public int CommentId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public string UserId { get; set; }
    }
}
