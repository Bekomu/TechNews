using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechNews.Core.Entities.Abstract
{
    public interface IUser
    {
        string Name { get; set; }
        string Surname { get; set; }
        string UserName { get; set; }
        string Token { get; set; }
        DateTime BirthDate { get; set; }
    }
}
