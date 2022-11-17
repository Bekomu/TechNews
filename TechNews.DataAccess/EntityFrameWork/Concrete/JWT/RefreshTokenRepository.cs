using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Core.DataAccess.Base;
using TechNews.DataAccess.Abstract.JWT;
using TechNews.DataAccess.EntityFrameWork.Context;
using TechNews.Entity.Concrete.JWT;

namespace TechNews.DataAccess.EntityFrameWork.Concrete.JWT
{
    public class RefreshTokenRepository : BaseRepository<RefreshToken, TechNewsDbContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(TechNewsDbContext techNewsDbContext) : base(techNewsDbContext)
    {

    }
}
}
