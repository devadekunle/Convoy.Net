using System.Net;
using System.Text;
using System.Text.Json;

namespace Convoy.NET.UnitTests;

public class FakeHttpMessageHandler<T> : HttpMessageHandler
{
    public FakeHttpMessageHandler(T response, HttpStatusCode statusCode)
    {
        Response = response;
        StatusCode = statusCode;
    }
    public string Url { get; private set; }
    public int NumberOfCalls { get; private set; }
    private T Response { get; }
    private HttpStatusCode StatusCode { get; }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        NumberOfCalls++;
        Url = request.RequestUri.ToString();
        return new HttpResponseMessage
        {
            StatusCode = StatusCode,
            Content = new StringContent(JsonSerializer.Serialize(Response), Encoding.UTF8, "application/json")
        };
    }
}