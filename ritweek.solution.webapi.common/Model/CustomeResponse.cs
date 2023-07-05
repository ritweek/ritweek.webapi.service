using System.Diagnostics.CodeAnalysis;

namespace ritweek.solution.webapi.common.Model
{
    [ExcludeFromCodeCoverage]
    public class CustomResponse
    {
        public string Title { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}

