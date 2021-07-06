using CleanArchitectureExample.Application.CQRS;
using CleanArchitectureExample.Domain;

namespace CleanArchitectureExample.Application.Students.Queries.GetStudentWithEagerLoadedCourses
{
    public class GetStudentWithEagerLoadedCoursesQuery : IQuery<Student>
    {
        public int StudentId { get; }

        public GetStudentWithEagerLoadedCoursesQuery(int studentId)
        {
            StudentId = studentId;
        }
    }
}
