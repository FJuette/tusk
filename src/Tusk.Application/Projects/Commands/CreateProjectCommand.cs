using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Tusk.Domain;

namespace Tusk.Application.Projects.Commands
{
    public class CreateProjectCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository repository;
        public CreateProjectCommandHandler(IProjectRepository repository)
        {
            this.repository = repository;
        }
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = new Project
            {
                Name = request.Name
            };

            // Return the db id of the created entry, Task.FromResult to fake async
            entity = await repository.AddAsync(entity);
            return entity.Id;
        }
    }

    public class CreateProjectValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectValidator()
        {
            RuleFor(x => x.Name).MaximumLength(50).NotEmpty();
        }
    }
}