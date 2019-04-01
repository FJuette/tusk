using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Tusk.Domain;

namespace Tusk.Persistence
{
    public class TuskDbContext : DbContext
    {
        public TuskDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TuskDbContext).Assembly);
        }
    }
}