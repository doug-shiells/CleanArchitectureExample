using System;
using System.Collections.Generic;
using System.Linq;
using CleanArchitectureExample.Application.CQRS;
using CleanArchitectureExample.Application.Students.Commands.CreateStudent;
using CleanArchitectureExample.Application.Students.Queries;
using CleanArchitectureExample.Application.Students.Queries.GetStudentGithub;
using CleanArchitectureExample.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureExample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IQueryable<Student> students;
        private readonly IOperationInvoker _operationInvoker;

        public StudentController(IQueryable<Student> students, IOperationInvoker operationInvoker)
        {
            this.students = students;
            this._operationInvoker = operationInvoker;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudentsNamedSmith()
        {
            return Ok(students.Where(s => StudentQueries.GetStudentBySurname(s, "Smith")).ToList());
        }
        
        [HttpGet("{id}")]
        public ActionResult<List<StudentGithubDto>> GetStudentsGithubsInCourse(int id)
        {
            return Ok(_operationInvoker.RunQuery(new GetStudentsGithubQuery(id)));
        }
        [HttpPost]
        public ActionResult Post()
        {
            return 
                _operationInvoker.Invoke(
                    new CreateStudentCommand(
                        new Student
                        {
                            PublicKey = Guid.NewGuid(),
                            DateOfBirth = DateTime.Parse("28/11/1992"),
                            Firstname = "Jon",
                            Surname = "Smith"
                        })).ToActionResult();
        }

        [HttpPost("validation-error")]
        public ActionResult ValidationError()
        {
            return _operationInvoker.Invoke(
                new CreateStudentCommand(
                    new Student
                    {
                        PublicKey = Guid.NewGuid(),
                        DateOfBirth = DateTime.Now.AddDays(1),
                        Firstname = "Jon",
                        Surname = "Smith"
                    }))
                .ToActionResult();
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
