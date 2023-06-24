using Convoy.NET.Configuration;
using Convoy.NET.ServiceRegistration;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace Convoy.NET.UnitTests;

public class ServiceExtensionTests
{
    [Theory]
    [InlineData("", "nhunicbqvbyu26t8jhb29", "98t987464", "ConvoySettings.BaseUrl is null or empty")]
    [InlineData("agreetaete335", " ", "98t987464", "ConvoySettings.PersonalAccessToken is null or empty")]
    [InlineData("sdagetu356453467", "nhunicbqvbyu26t8jhb29", null, "ConvoySettings.OrganizationId is null or empty")]
    public void ServiceRegistration_ConvoySettingsInvalid_ThrowsException(
        string baseurl,
        string apikey,
        string organizationId,
        string expectedErrorMessage)
    {
        // Arrange
        var services = new ServiceCollection();
        var convoySettings = new ConvoySettings { BaseUrl = baseurl, PersonalAccessToken = apikey, OrganizationId = organizationId };
        // Act
        Action act = () => services.AddConvoy(convoySettings);

        // Assert
        act.Should().Throw<ArgumentException>().WithMessage(expectedErrorMessage);
    }
}