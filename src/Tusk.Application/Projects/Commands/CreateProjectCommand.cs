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

    public class CreateProductCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository repository;
        public CreateProductCommandHandler(IProjectRepository repository)
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

    public class CreateCustomerValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.Name).MaximumLength(50).NotEmpty();
        }
    }
}