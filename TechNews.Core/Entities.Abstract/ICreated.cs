using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechNews.Core.Entities.Abstract
{
    public interface ICreated
    {
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
    }
}
