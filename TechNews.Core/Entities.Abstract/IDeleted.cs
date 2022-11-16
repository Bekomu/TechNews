using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechNews.Core.Entities.Abstract
{
    public interface IDeleted
    {
        string DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
