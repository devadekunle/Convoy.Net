using Convoy.NET.Configuration;
using Convoy.NET.Constants;
using Convoy.NET.Contracts.V1.Requests;
using Convoy.NET.Contracts.V1.Responses;
using FluentResults;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http.Json;

namespace Convoy.NET.Clients.V1;

public class ConvoyClient : IConvoyClient
{
    private readonly HttpClient _httpClient;
    private readonly ConvoySettings _settings;
    private readonly ILogger<ConvoyClient> _logger;

    public ConvoyClient(HttpClient httpClient, ConvoySettings settings, ILogger<ConvoyClient> logger)
    {
        _httpClient = httpClient;
        _settings = settings;
        _logger = logger;
    }

    public async Task<Result<ConvoyProjectCreatedResponse>> CreateProjectAsync(CreateProject model, CancellationToken cancellationToken)
    {
        if (_logger is not null)
            _logger.LogInformation("HTTP POST - Create Convoy Project started.......");

        var url = $"{_httpClient.BaseAddress}{Api.Endpoints.V1.CreateProject}?orgID={_settings.OrganizationId}";
        try
        {
            var response = await _httpClient.PostAsJsonAsync(url, model, cancellationToken);
            return response.StatusCode switch
            {
                HttpStatusCode.Created => (await response.Content!.ReadFromJsonAsync<ConvoyProjectCreatedResponse>())!,
                _ => new Error((await response.Content!.ReadFromJsonAsync<BaseResponse>())!.Message)
            };
        }
        catch (Exception ex)
        {
            if (_logger is not null)
                _logger.LogError("An error occured while creating Convoy Project. See details {@Error}", ex);
            return new Error(ex.Message);
        }
    }
}