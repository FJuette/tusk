using System.Net.Http;
using System.Threading.Tasks;
using Tusk.Api.FunctionalTests.Common;
using Tusk.Application.Projects.Queries;
using Xunit;

namespace Tusk.Api.FunctionalTests.Controllers.Services
{
    public class ExportAll : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ExportAll(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsExportListViewModel()
        {
            var response = await _client.GetAsync("api/projects");

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<ProjectsListViewModel>(response);

            Assert.IsType<ProjectsListViewModel>(vm);
            Assert.NotEmpty(vm.Projects);
        }
    }
}