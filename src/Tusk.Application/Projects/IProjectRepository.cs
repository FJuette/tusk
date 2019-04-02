using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tusk.Domain;

namespace Tusk.Application
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
    }
}