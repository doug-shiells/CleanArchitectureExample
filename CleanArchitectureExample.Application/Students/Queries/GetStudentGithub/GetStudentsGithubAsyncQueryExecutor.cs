using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureExample.Application.CQRS;
using CleanArchitectureExample.Application.Persistence;
using CleanArchitectureExample.Application.Persistence.Extensions;
using CleanArchitectureExample.Domain;

namespace CleanArchitectureExample.Application.Students.Queries.GetStudentGithub
{
    internal class GetStudentsAsyncGithubQueryExecutor : IAsyncQueryExecutor<GetStudentsGithubQuery, List<StudentGithubDto>>
    {
        private readonly IQueryable<Student> students;

        public GetStudentsAsyncGithubQueryExecutor(IQueryable<Student> students)
        {
            this.students = students;
        }

        public async Task<List<StudentGithubDto>> ExecuteQueryAsync(GetStudentsGithubQuery contract)
        {
            var studentsInCourse =
                await students.Where(s =>
                        s.Courses.Any(c => c.CourseId == contract.CourseId))
                    .ToListAsync();

            return studentsInCourse.Select(GetStudentsGitHubDetails).ToList();
        }
        
        private StudentGithubDto GetStudentsGitHubDetails(Student student)
        {
            return new StudentGithubDto(1, "github-login");
        }


    }
}
