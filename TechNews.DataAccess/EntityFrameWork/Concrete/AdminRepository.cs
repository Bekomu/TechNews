using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Core.DataAccess.Base;
using TechNews.DataAccess.Abstract;
using TechNews.DataAccess.EntityFrameWork.Context;
using TechNews.Entity.Concrete;

namespace TechNews.DataAccess.EntityFrameWork.Concrete
{
    public class AdminRepository : BaseRepository<Admin, TechNewsDbContext>, IAdminRepository
    {
        public AdminRepository(TechNewsDbContext techNewsDbContext) : base(techNewsDbContext)
        {

        }
    }
}
