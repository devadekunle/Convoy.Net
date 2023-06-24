using Convoy.NET.Clients.V1;
using Convoy.NET.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Convoy.NET.ServiceRegistration;

public static class ServiceExtension
{
    public static IServiceCollection AddConvoy(this IServiceCollection services, ConvoySettings settings)
    {
        ValidateSettings(settings);

        services.AddSingleton(settings);
        services.AddHttpClient<IConvoyClient, ConvoyClient>(client =>
        {
            client.BaseAddress = new Uri(settings.BaseUrl);
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {settings.PersonalAccessToken}");
        });
        return services;
    }

    private static void ValidateSettings(ConvoySettings settings)
    {
        if (string.IsNullOrWhiteSpace(settings.BaseUrl))
            throw new ArgumentException("ConvoySettings.BaseUrl is null or empty");

        if (string.IsNullOrWhiteSpace(settings.PersonalAccessToken))
            throw new ArgumentException("ConvoySettings.PersonalAccessToken is null or empty");

        if (string.IsNullOrWhiteSpace(settings.OrganizationId))
            throw new ArgumentException("ConvoySettings.OrganizationId is null or empty");
    }
}