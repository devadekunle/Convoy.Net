using Convoy.NET.Contracts.V1.Requests;
using Convoy.NET.Contracts.V1.Responses;
using FluentResults;

namespace Convoy.NET.Clients.V1;

public interface IConvoyClient
{
    Task<Result<ConvoyProjectCreatedResponse>> CreateProjectAsync(CreateProject model, CancellationToken cancellationToken);
}