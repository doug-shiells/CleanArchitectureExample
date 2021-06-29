using System;
namespace CleanArchitectureExample.Api.Models
{
    public class CreateStudentRequest
    {
        public DateTime DateOfBirth { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
    }
}
