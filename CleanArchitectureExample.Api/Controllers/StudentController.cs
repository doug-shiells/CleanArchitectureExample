﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureExample.Application.CQRS;
using CleanArchitectureExample.Application.Students;
using CleanArchitectureExample.Application.Students.Commands;
using CleanArchitectureExample.Application.Students.Queries;
using CleanArchitectureExample.Application.Students.Queries.GetStudentGithub;
using CleanArchitectureExample.Domain;
using Microsoft.AspNetCore.Mvc;

namespace AutoGeneratedRepositories.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IQueryable<Student> students;
        private readonly ICommandInvoker commandInvoker;

        public StudentController(IQueryable<Student> students, ICommandInvoker commandInvoker)
        {
            this.students = students;
            this.commandInvoker = commandInvoker;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudentsNamedSmith()
        {
            return Ok(students.Where(s => StudentQueries.GetStudentBySurname(s, "Smith")).ToList());
        }
        
        [HttpGet("{id}")]
        public ActionResult<List<StudentGithubDto>> GetStudentsGithubsInCourse(int id)
        {
            return Ok(commandInvoker.RunQuery(new GetStudentsGithubQuery(id)));
        }
        
        [HttpPost]
        public void Post()
        {
            commandInvoker.Invoke(
                new CreateStudentCommand(
                    new Student
                    {
                        DateOfBirth = DateTime.Parse("28/11/1992"),
                        Firstname = "Jon",
                        Surname = "Smith"
                    }));
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
