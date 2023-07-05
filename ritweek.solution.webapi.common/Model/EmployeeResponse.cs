using System.Diagnostics.CodeAnalysis;

namespace ritweek.solution.webapi.common.Model
{
    [ExcludeFromCodeCoverage]
    public class EmployeeResponse<T> : CustomResponse
    {
        public T Data { get; set; }
    }
}

