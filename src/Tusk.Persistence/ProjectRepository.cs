using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tusk.Application;
using Tusk.Domain;

namespace Tusk.Persistence
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly TuskDbContext _context;
        public ProjectRepository(TuskDbContext context) : base(context)
        {
            this._context = context;
        }
    }
}