using AutoFixture;
using Convoy.NET.Clients.V1;
using Convoy.NET.Configuration;
using Convoy.NET.Contracts.V1.Requests;
using Convoy.NET.Contracts.V1.Responses;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Net;

namespace Convoy.NET.UnitTests;

public class ConvoyClientTests
{
    [Theory]
    [InlineData("http://myconvoy.com", "23456789", "http://myconvoy.com/api/v1/projects?orgID=23456789")]
    public async void CreateProjectAsync_GivenConfiguration_CallsValidEndpoint(string baseurl, string organizationId, string expectedEndpoint)
    {
        //Arrange
        var fixture = new Fixture();

        var response = fixture.Create<ConvoyProjectCreatedResponse>();
        var request = fixture.Create<CreateProject>();
        var httpResponseHandler = new FakeHttpMessageHandler<ConvoyProjectCreatedResponse>(response, HttpStatusCode.Created);
        var httpClient = new HttpClient(httpResponseHandler);
        httpClient.BaseAddress = new Uri(baseurl);
        var logger = Substitute.For<ILogger<ConvoyClient>>();
        var convoySettings = new ConvoySettings
        {
            BaseUrl = baseurl,
            OrganizationId = organizationId
        };
        var convoyClient = new ConvoyClient(httpClient, convoySettings, logger);

        //Act
        _ = await convoyClient.CreateProjectAsync(request, CancellationToken.None);

        //Assert
        httpResponseHandler.Url.Should().Be(expectedEndpoint);
    }
}