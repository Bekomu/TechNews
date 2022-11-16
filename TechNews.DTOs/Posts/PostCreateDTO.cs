using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechNews.DTOs.Posts
{
    public class PostCreateDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageURL { get; set; }

        public Guid AuthorId { get; set; }
    }
}
