using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Core.Result;
using TechNews.Dtos.Admins;

namespace TechNews.Business.Abstract
{
    public interface IAdminService
    {
        Task<IDataResult<List<AdminDTO>>> GetAll();
        Task<IDataResult<AdminDTO>> GetById(Guid id);
        Task<IDataResult<AdminDTO>> Add(AdminCreateDTO createAdminDto);
        Task<IDataResult<AdminDTO>> Update(AdminUpdateDTO updateAdminDto);
        Task<IResult> Delete(Guid id);
    }
}
