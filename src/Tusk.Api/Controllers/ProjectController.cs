using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tusk.Application;
using Tusk.Application.Projects.Commands;
using Tusk.Application.Projects.Queries;
using Tusk.Domain;

namespace Tusk.Api.Controllers
{
    public class ProjectController : BaseController
    {
        [HttpGet("api/projects")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ProjectsListViewModel>> Projects()
        {
            return Ok(await Mediator.Send(new GetAllProjectsQuery()));
        }

        [HttpGet("api/projects/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProjectsListViewModel>> Project(int id)
        {
            return Ok(await Mediator.Send(new GetProjectQuery(id)));
        }

        [HttpPost("api/projects")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<int>> Create([FromBody] CreateProjectCommand command)
        {
            var projectId = await Mediator.Send(command);
            return Ok(projectId);
        }

        [HttpDelete("api/projects/{id}")]
        public async Task<ActionResult<int>> Delete(int id)
        {
            var projectId = await Mediator.Send(new DeleteProjectCommand(id));
            return Ok(projectId);
        }
    }
}