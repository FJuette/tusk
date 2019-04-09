using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tusk.Application.Exceptions;
using Tusk.Domain;

namespace Tusk.Application.Projects.Commands
{
    public class UpdateProjectCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, int>
    {
        private readonly IProjectRepository _repository;

        public UpdateProjectCommandHandler(IProjectRepository repository)
        {
            this._repository = repository;
        }

        public async Task<int> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            // TODO add fluent validation....

            entity.Name = request.Name;

            await _repository.UpdateAsync(entity);
            return entity.Id;
        }
    }
}