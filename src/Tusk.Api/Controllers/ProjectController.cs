using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tusk.Application;
using Tusk.Application.Projects.Commands;
using Tusk.Application.Projects.GetProject;
using Tusk.Application.Projects.Queries;
using Tusk.Domain;

namespace Tusk.Api.Controllers
{
    public class ProjectController : BaseController
    {
        [HttpGet("api/projects")]
        public async Task<ActionResult<ProjectsListViewModel>> Projects()
        {
            return Ok(await Mediator.Send(new GetAllProjectsQuery()));
        }

        [HttpGet("api/projects/{id}")]
        public async Task<ActionResult<ProjectsListViewModel>> Project(int id)
        {
            return Ok(await Mediator.Send(new GetProjectQuery(id)));
        }

        [HttpPost("api/projects")]
        public async Task<ActionResult<int>> Create([FromBody] CreateProjectCommand command)
        {
            var projectId = await Mediator.Send(command);
            return Ok(projectId);
        }
    }
}