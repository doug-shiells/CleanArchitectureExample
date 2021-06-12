using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureExample.Application.CQRS;
using CleanArchitectureExample.Application.Persistence;
//using CleanArchitectureExample.Application.Persistence.Extensions;
using CleanArchitectureExample.Application.Students.Commands.CreateStudent;
using CleanArchitectureExample.Application.Students.Queries;
using CleanArchitectureExample.Application.Students.Queries.GetStudentGithub;
using CleanArchitectureExample.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureExample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IAsyncQueryable<Student> students;
        private readonly IOperationInvoker _operationInvoker;

        public StudentController(IAsyncQueryable<Student> students, IOperationInvoker operationInvoker)
        {
            this.students = students;
            this._operationInvoker = operationInvoker;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsNamedSmith()
        {
            var dd = students.Where(s => StudentQueries.GetStudentBySurname(s, "Smith"));//.FirstOrDefaultAsync();

            return Ok(await students.Where(s => StudentQueries.GetStudentBySurname(s, "Smith")).ToListAsync());
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<List<StudentGithubDto>>> GetStudentsGithubsInCourse(int id)
        {
            return Ok(await _operationInvoker.RunQueryAsync(new GetStudentsGithubQuery(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Post()
        {
            return 
                (await _operationInvoker.InvokeAsync(
                    new CreateStudentCommand(
                        new Student
                        {
                            PublicKey = Guid.NewGuid(),
                            DateOfBirth = DateTime.Parse("28/11/1992"),
                            Firstname = "Jon",
                            Surname = "Smith"
                        }))).ToActionResult();
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
