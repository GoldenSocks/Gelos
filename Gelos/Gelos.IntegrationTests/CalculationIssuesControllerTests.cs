using Gelos.API.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace Gelos.IntegrationTests
{
    public class CalculationIssuesControllerTests
    {
        [Fact]
        public async Task Create_ShouldReturnOK()
        {
            var application = new WebApplicationFactory<Program>();

            var client = application.CreateClient();
            var request = new CreateCalculationIssueRequest()
            {
                Name = "Name",
                Description = "Description"
            };

            var response = await client.PostAsJsonAsync("CalculationIssues", request);

            response.EnsureSuccessStatusCode();
        }
    }
}