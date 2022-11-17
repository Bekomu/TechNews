using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Core.DataAccess.Abstract;
using TechNews.Entity.Concrete.JWT;

namespace TechNews.DataAccess.Abstract.JWT
{
    public interface IRefreshTokenRepository : IRepository<RefreshToken>
    {
    }
}
