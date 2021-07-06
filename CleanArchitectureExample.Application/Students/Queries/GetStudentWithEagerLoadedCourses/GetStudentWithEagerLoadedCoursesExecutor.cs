using System.Linq;
using CleanArchitectureExample.Application.CQRS;
using CleanArchitectureExample.Application.Persistence;
using CleanArchitectureExample.Application.Persistence.Extensions;
using CleanArchitectureExample.Application.Students.Queries.GetStudentGithub;
using CleanArchitectureExample.Domain;

namespace CleanArchitectureExample.Application.Students.Queries.GetStudentWithEagerLoadedCourses
{

    internal class GetStudentWithEagerLoadedCoursesExecutor : IQueryExecutor<GetStudentWithEagerLoadedCoursesQuery, Student>
    {
        private readonly IQueryable<Student> students;

        public GetStudentWithEagerLoadedCoursesExecutor(IQueryable<Student> students)
        {
            this.students = students;
        }

        public Student ExecuteQuery(GetStudentWithEagerLoadedCoursesQuery contract)
        {
            return students
                .Include(s => s.Courses)
                .ThenInclude(c => c.Course)
                .SingleOrDefault(s => s.StudentId == 1);
        }
        
        private StudentGithubDto GetStudentsGitHubDetails(Student student)
        {
            return new StudentGithubDto(1, "github-login");
        }


    }
}
