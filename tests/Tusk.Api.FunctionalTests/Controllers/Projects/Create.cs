using System.Net.Http;
using Tusk.Api.FunctionalTests.Common;
using Xunit;

namespace Tusk.Api.FunctionalTests.Controllers.Projects
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }
        
    }
}