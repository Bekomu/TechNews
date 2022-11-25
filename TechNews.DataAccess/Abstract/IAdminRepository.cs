using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Core.DataAccess.Abstract;
using TechNews.Entity.Concrete;

namespace TechNews.DataAccess.Abstract
{
    public interface IAdminRepository : IRepository<Admin>
    {
        Task<Admin> GetByEmail(string email);
    }
}
