using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tusk.Domain;

namespace Tusk.Application.Projects.Queries
{
    public class GetAllProjectsQuery : IRequest<ProjectsListViewModel>
    {   
    }

    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, ProjectsListViewModel>
    {
        private readonly IProjectRepository _repository;
        public GetAllProjectsQueryHandler(IProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProjectsListViewModel> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            // Use async calls if possible
            var projects = _repository.All().Select(ProjectDto.Projection).ToList();

            var model = new ProjectsListViewModel
            {
                Projects = projects
            };
            return model;
        }
    }

    // Every request has its own view model
    public class ProjectsListViewModel
    {
        public IEnumerable<ProjectDto> Projects { get; set; }
    }

    /*
    The Data Transfer Object "DTO", is a simple serializable object used to transfer data across multiple layers 
    of an application. The fields contained in the DTO are usually primitive types such as strings, boolean, etc. 
    Other DTOs may be contained or aggregated in the DTO
     */
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Use Automapper for simple mapping and project for complex (e. g. need to load reference data)
        public static Expression<Func<Project, ProjectDto>> Projection
        {
            get
            {
                return c => new ProjectDto
                {
                    Id = c.Id,
                    Name = c.Name
                };
            }
        }
    }
}