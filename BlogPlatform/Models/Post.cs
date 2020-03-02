using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPlatform.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string PublishDate { get; set; }
        public virtual Category Category { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual ICollection<PostTag> PostTag { get; set; }

        //public List<Tag> Tag { get; set; }
        //public virtual int TagId { get; set; }
        public virtual int CategoryId { get; set; }
        //public virtual ICollection<Post> Post { get; set; }
    }
}
