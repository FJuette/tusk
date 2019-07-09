using Microsoft.EntityFrameworkCore;
using Tusk.Application.Interfaces;
using Tusk.Domain;

namespace Tusk.Persistence
{
    public class TuskDbContext : DbContext, ITuskDbContext
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