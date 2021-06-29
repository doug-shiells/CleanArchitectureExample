using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureExample.Api.Models;
using CleanArchitectureExample.Application.CQRS;
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
        private readonly IQueryable<Student> students;
        private readonly IOperationInvoker _operationInvoker;

        public StudentController(IQueryable<Student> students, IOperationInvoker operationInvoker)
        {
            this.students = students;
            this._operationInvoker = operationInvoker;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsNamedSmith()
        {
            return Ok(await students.Where(s => StudentQueries.GetStudentBySurname(s, "Smith")).ToListAsync());
        }

        [HttpGet("list")]
        public async Task<ActionResult<IEnumerable<Student>>> GetSudentList()
        {
            return Ok(await students.Take(100).ToListAsync());
        }

        [HttpGet("public-key/{key}")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsNamedSmith(Guid publicKey)
        {
            return Ok(await students.Where(s => s.PublicKey == publicKey).ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<StudentGithubDto>>> GetStudentsGithubsInCourse(int id)
        {
            return Ok(await _operationInvoker.RunQueryAsync(new GetStudentsGithubQuery(id)));
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateStudentRequest studentRequest)
        {
            return 
                (await _operationInvoker.InvokeAsync(
                    new CreateStudentCommand(
                        new Student
                        {
                            PublicKey = Guid.NewGuid(),
                            DateOfBirth = studentRequest.DateOfBirth,
                            Firstname = studentRequest.Firstname,
                            Surname = studentRequest.Surname
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
