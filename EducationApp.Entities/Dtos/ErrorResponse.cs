using System.Net;

namespace EducationApp.Entities.Dtos
{
    public class ErrorResponse
    {
        public bool Success { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public int StatusCodeNumber { get; set; }

        public string Message { get; set; } 
    }
}
