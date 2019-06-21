using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tusk.Domain;

namespace Tusk.Application.Interfaces
{
    public interface ITuskDbContext
    {
        DbSet<Project> Projects { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();
    }
}