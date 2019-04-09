using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Tusk.Application.Exceptions;
using Tusk.Domain;

namespace Tusk.Application.Projects.Commands
{
    public class DeleteProjectCommand : IRequest<int>
    {
        public DeleteProjectCommand(int id)
        {
            this.Id = id;

        }
        public int Id { get; }
    }

    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, int>
    {
        private readonly IProjectRepository _repository;
        public DeleteProjectCommandHandler(IProjectRepository repository)
        {
            this._repository = repository;

        }

        public async Task<int> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.FindAsync(request.Id);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            // TODO add more checks, e. g. check for existing epics and throw an Exception, e. g. DeleteFailureException
            // TODO handle exception in filter

            await _repository.DeleteAsync(entity);
            return entity.Id;
        }
    }
}