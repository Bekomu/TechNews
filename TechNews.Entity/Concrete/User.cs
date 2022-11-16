using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Core.Entities.Abstract;

namespace TechNews.Entity.Concrete
{
    public class User : BaseEntity, IUser
    {
        public string IdentityId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Token { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
