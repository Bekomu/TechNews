using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Core.DataAccess.Base;
using TechNews.Core.Enums;
using TechNews.DataAccess.Abstract;
using TechNews.DataAccess.EntityFrameWork.Context;
using TechNews.Entity.Concrete;

namespace TechNews.DataAccess.EntityFrameWork.Concrete
{
    public class AdminRepository : BaseRepository<Admin, TechNewsDbContext>, IAdminRepository
    {
        private readonly TechNewsDbContext _techNewsDbContext;

        public AdminRepository(TechNewsDbContext techNewsDbContext) : base(techNewsDbContext)
        {
            _techNewsDbContext = techNewsDbContext;
        }
        public async Task<Admin> GetByEmail(string email)
        {
            var admin = _techNewsDbContext.Admins.FirstOrDefault(x => x.Email == email);

            return admin == null ? null : (admin.Status != Status.Deleted ? admin : null);
        }
    }
}
