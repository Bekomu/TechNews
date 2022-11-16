using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Core.Entities.Abstract;

namespace TechNews.Entity.Concrete
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageURL { get; set; }

        public Guid AuthorId { get; set; }
        public virtual Admin Author { get; set; }

    }
}
