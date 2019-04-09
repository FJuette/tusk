using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Tusk.Application.Exceptions;
using Tusk.Domain;

namespace Tusk.Application.Projects.Queries
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
        private readonly IProjectRepository _repository;
        private readonly IMapper _mapper;
        public GetProjectQueryHandler(IProjectRepository repository, IMapper mapper)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        public async Task<ProjectViewModel> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            var project = await _repository.FindAsync(request.Id);
            if (project == null)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }
            var projectViewModel = _mapper.Map<ProjectViewModel>(project);
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

    public class GetProjectProfile : Profile
    {
        public GetProjectProfile()
        {
            CreateMap<Project, ProjectViewModel>();
        }
    }
}