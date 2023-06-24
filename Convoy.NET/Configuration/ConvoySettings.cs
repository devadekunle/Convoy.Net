namespace Convoy.NET.Configuration;

public sealed class ConvoySettings
{
    /// <summary>
    /// This is the host part of the url for your Convoy instance e.g http://thisismyconvoyinstance.here
    /// </summary>
    public string BaseUrl { get; init; } = string.Empty;

    /// <summary>
    /// Personal Access Token / API key for the organization
    /// </summary>
    public string PersonalAccessToken { get; init; } = string.Empty;

    /// <summary>
    /// Organization Unique Identifier
    /// </summary>
    public string OrganizationId { get; init; } = string.Empty;
}