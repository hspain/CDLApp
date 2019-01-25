using CieDigitalAssessment;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.PlatformAbstractions;
using System;
using System.IO;
using System.Net.Http;

namespace CieDigitalAssessment.Test
{
    public class TestServerFixture : IDisposable
    {
        private readonly TestServer _testServer;
        public HttpClient Client { get; }

        // This fixture can be used in unit testing classes to setup a web client
        // including our custom Startup class we built in the API
        public TestServerFixture()
        {
            var builder = new WebHostBuilder()
                   .UseContentRoot(GetContentRootPath())
                   .UseEnvironment("Development")
                   .UseStartup<Startup>();  

            _testServer = new TestServer(builder);
            Client = _testServer.CreateClient();

        }

        // This is needed to get access to the appsettings.json file.  Particularly important
        // for the connection strings to the database
        private string GetContentRootPath()
        {
            var testProjectPath = PlatformServices.Default.Application.ApplicationBasePath;
            var relativePathToHostProject = @"..\..\..\..\CieDigitalAssessment";
            return Path.Combine(testProjectPath, relativePathToHostProject);
        }

        public void Dispose()
        {
            Client.Dispose();
            _testServer.Dispose();
        }
    }
}