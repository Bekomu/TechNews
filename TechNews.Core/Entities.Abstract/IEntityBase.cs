using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechNews.Core.Entities.Abstract
{
    public interface IEntityBase : IEntity, ICreated, IDeleted, IModified
    {
    }
}
