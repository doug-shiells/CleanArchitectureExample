using System.Collections.Generic;
using System.Linq;
using CleanArchitectureExample.Application.CQRS;
using CleanArchitectureExample.Application.Persistence;
using CleanArchitectureExample.Domain;

namespace CleanArchitectureExample.Application.Students.Queries.GetStudentGithub
{

    internal class GetStudentsGithubQueryExecutor : IQueryExecutor<GetStudentsGithubQuery, List<StudentGithubDto>>
    {
        private readonly IQueryable<Course> courses;

        public GetStudentsGithubQueryExecutor(IQueryable<Course> courses)
        {
            this.courses = courses;
        }

        public List<StudentGithubDto> ExecuteQuery(GetStudentsGithubQuery contract)
        {
            return
                courses.SingleOrDefault(c => c.CourseId == contract.CourseId)
                      ?.Students
                      ?.Select(sc => sc.Student)
                       .Select(GetStudentsGitHubDetails)
                       .ToList()
                ?? new List<StudentGithubDto>();
        }
        
        private StudentGithubDto GetStudentsGitHubDetails(Student student)
        {
            return new StudentGithubDto(1, "github-login");
        }


    }
}
