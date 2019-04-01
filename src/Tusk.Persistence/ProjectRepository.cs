using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tusk.Application;
using Tusk.Domain;

namespace Tusk.Persistence
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TuskDbContext _context;
        public ProjectRepository(TuskDbContext context)
        {
            this._context = context;
        }

        public async Task<int> Add(Project p)
        {
            await _context.Projects.AddAsync(p);
            await _context.SaveChangesAsync();
            return p.Id;
        }

        public IQueryable<Project> GetAll()
        {
            return _context.Projects;
        }
    }
}