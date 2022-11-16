using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Core.DataAccess.Mapping;
using TechNews.Entity.Concrete;

namespace TechNews.Mapping.EntityMapping
{
    public class AdminMapping : MapBase<Admin>
    {
        public override void Configure(EntityTypeBuilder<Admin> builder)
        {
            base.Configure(builder);
            builder.HasMany(x => x.Posts).WithOne(x => x.Author).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
