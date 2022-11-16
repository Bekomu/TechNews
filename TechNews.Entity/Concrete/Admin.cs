using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechNews.Entity.Concrete
{
    public class Admin : User
    {
        public virtual List<Post> Posts { get; set; }
    }
}
