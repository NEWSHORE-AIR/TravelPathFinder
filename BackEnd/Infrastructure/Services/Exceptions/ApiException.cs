using System.Net;

namespace TravelPathFinder.Infrastructure.Services
{
public class ApiException : Exception
{
    public HttpStatusCode StatusCode { get; }
        public string? ErrorMessage { get; set; }
        public HttpStatusCode? ErrorCode { get; set; }

        public ApiException(string message, HttpStatusCode statusCode)
        : base(message)
    {
        StatusCode = statusCode;
    }
}
}
