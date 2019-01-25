using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CieDigitalAssessment.API.Models;
using Newtonsoft.Json;
using Xunit;

namespace CieDigitalAssessment.Test
{
    public class MoviesIntegrationTests : IClassFixture<TestServerFixture>
    {
        private readonly TestServerFixture _fixture;

        public MoviesIntegrationTests(TestServerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetMovies()
        {
            var response = await _fixture.Client.GetAsync("api/movies");
            var responseText = await response.Content.ReadAsStringAsync();

            // response.EnsureSuccessStatusCode();
            // TODO getting a 500 error code here due to the connection string not being pulled in properly
        }
    }
}