using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechNews.Core.Entities.Abstract;
using TechNews.Entity.Concrete;
using TechNews.Mapping.EntityMapping;

namespace TechNews.DataAccess.EntityFrameWork.Context
{
    public class TechNewsDbContext : IdentityDbContext
    {
        public TechNewsDbContext(DbContextOptions<TechNewsDbContext> options) : base(options)
        {

        }


        public DbSet<Admin> Admins { get; set; }
        public DbSet<Post> Posts { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<User>();

            builder.ApplyConfigurationsFromAssembly(typeof(IMapping).Assembly);
            base.OnModelCreating(builder);

        }
        public override int SaveChanges()
        {
            SetBaseProperties();
            return base.SaveChanges();

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetBaseProperties();
            return await base.SaveChangesAsync(cancellationToken);
        }
        private void SetBaseProperties()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            foreach (var entry in entries)
            {
                SetIfAdded(entry);
                SetIfModify(entry);
                SetIfDeleted(entry);
            }
        }
        private void SetIfModify(EntityEntry<BaseEntity> entityEntry)
        {
            if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Entity.Status = Core.Enums.Status.Modified;
            }

            entityEntry.Entity.ModifiedBy = " ";
            entityEntry.Entity.ModifiedDate = System.DateTime.Now;
        }

        private void SetIfAdded(EntityEntry<BaseEntity> entityEntry)
        {
            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Entity.Status = Core.Enums.Status.Added;
                entityEntry.Entity.CreatedBy = " ";
                entityEntry.Entity.CreatedDate = System.DateTime.Now;
            }
        }

        private void SetIfDeleted(EntityEntry<BaseEntity> entityEntry)
        {
            if (entityEntry.State == EntityState.Deleted)
            {
                entityEntry.State = EntityState.Modified;
                entityEntry.Entity.Status = Core.Enums.Status.Deleted;
                entityEntry.Entity.DeletedBy = " ";
                entityEntry.Entity.DeletedDate = System.DateTime.Now;
            }
        }
    }
}
