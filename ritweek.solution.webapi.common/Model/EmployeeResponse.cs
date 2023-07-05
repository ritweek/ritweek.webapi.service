using System;
namespace ritweek.solution.webapi.common.Model
{
    public class EmployeeResponse<T> : CustomResponse
    {
        public T Data { get; set; }
    }
}

