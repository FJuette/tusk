using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tusk.Application.Exceptions;
using Tusk.Domain;

namespace Tusk.Application.Projects.GetProject
{
    public class GetProjectQuery : IRequest<ProjectViewModel>
    {
        public GetProjectQuery(int id)
        {
            this.Id = id;
        }
        public int Id { get; }
    }

    public class GetProjectQueryHandler : IRequestHandler<GetProjectQuery, ProjectViewModel>
    {
        private readonly IProjectRepository repository;
        public GetProjectQueryHandler(IProjectRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ProjectViewModel> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await repository.FindAsync(request.Id);
            if (project == null)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }
            // TODO Better use projection or automapper here
            var projectViewModel = new ProjectViewModel
            {
                Id = project.Id,
                Name = project.Name
            };
            // Do more with the viewmodel, e. g. set user permissions
            projectViewModel.CanEdit = true;
            projectViewModel.CanRemove = false;
            return projectViewModel;
        }
    }

    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // User permissions
        public bool CanEdit { get; set; }
        public bool CanRemove { get; set; }
    }
}