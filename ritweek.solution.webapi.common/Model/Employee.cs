﻿using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ritweek.solution.webapi.common.Model
{
    [ExcludeFromCodeCoverage]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public int Age { get; set; }

        public static implicit operator List<object>(Employee v)
        {
            throw new NotImplementedException();
        }
    }

}

